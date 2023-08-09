namespace AngularTodoWebAPI.DataAccessObject
{
    public class TodoListMSSQLDao : ITodoListDao
    {
        private readonly TodoContext _dbContext;
        private readonly ILogger _logger;

        public TodoListMSSQLDao(TodoContext dbContext, ILogger logger)
        {
            this._dbContext = dbContext;
            this._logger = logger;
        }

        public async Task<TodoListDto> CreateTodoRecord(TodoListDto newTodo)
        {
            try
            {
                var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    TodoList todoRecordToDB = new TodoList()
                    {
                        TodoId = new Guid(),
                        Status = newTodo.Status,
                        Context = newTodo.Context,
                        Editing = newTodo.Editing
                    };

                    await _dbContext.TodoLists.AddAsync(todoRecordToDB);
                    await _dbContext.SaveChangesAsync();

                    await dbTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await dbTransaction.RollbackAsync();
                    _logger.Error($"資料庫交易(Transaction)時發生問題: {ex}");
                    throw new Exception($"資料庫交易(Transaction)時發生問題", ex);
                }
                finally
                {
                    await dbTransaction.DisposeAsync();
                }

                //product.ProductId = GetProductByName(product.ProductName).Result.ProductId;
                return newTodo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<TodoList> GetTodoRecordById(Guid todoRecordId)
        {
            try
            {
                var todoRecord = await _dbContext.TodoLists.SingleOrDefaultAsync(x => x.TodoId == todoRecordId);
                if (todoRecord == null)
                {
                    _logger.Error($"找不到紀錄，紀錄編號: {todoRecordId} 不存在");
                    throw new Exception($"找不到紀錄，紀錄編號: {todoRecordId} 不存在");
                }
                return todoRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<TodoList> GetTodoRecordByContext(string context)
        {
            try
            {
                var todoRecord = await _dbContext.TodoLists.SingleOrDefaultAsync(x => x.Context == context);
                if (todoRecord == null)
                {
                    _logger.Error($"找不到紀錄， {context} 不存在");
                    throw new Exception($"找不到紀錄， {context} 不存在");
                }
                return todoRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<TodoListDto>> GetAllTodoList()
        {
            try
            {
                var todoList = await _dbContext.TodoLists.Select(x => new TodoListDto
                {
                    TodoId = x.TodoId,
                    Status = x.Status,
                    Context = x.Context,
                    Editing = x.Editing
                }).OrderBy(x => x.TodoId).AsNoTracking().ToListAsync();

                return todoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<TodoListDto> UpdateTodoRecord(TodoListDto todoRecord)
        {
            try
            {
                var todoRecordToUpdate = await GetTodoRecordById(todoRecord.TodoId);

                var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    todoRecordToUpdate.Status = todoRecord.Status;
                    todoRecordToUpdate.Editing = todoRecord.Editing;
                    todoRecordToUpdate.Context = todoRecord.Context;

                    await _dbContext.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // 發生例外時進行回滾
                    await dbTransaction.RollbackAsync();
                    // 將例外訊息記錄至日誌
                    _logger.Error($"資料庫交易(Transaction)時發生問題: {ex}");
                    throw new Exception($"資料庫交易(Transaction)時發生問題", ex);
                }
                finally
                {
                    await dbTransaction.DisposeAsync();
                }

                return todoRecord;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<List<TodoListDto>> DeleteTodoRecord(Guid todoRecordId)
        {
            try
            {
                var todoRecordToDelete = await GetTodoRecordById(todoRecordId);

                var dbTransaction = await _dbContext.Database.BeginTransactionAsync();
                try
                {
                    _dbContext.TodoLists.Remove(todoRecordToDelete);
                    await _dbContext.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // 發生例外時進行回滾
                    await dbTransaction.RollbackAsync();
                    // 將例外訊息記錄至日誌
                    _logger.Error($"資料庫交易(Transaction)時發生問題: {ex}");
                    throw new Exception($"資料庫交易(Transaction)時發生問題", ex);
                }
                finally
                {
                    await dbTransaction.DisposeAsync();
                }

                var result = await GetAllTodoList();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
