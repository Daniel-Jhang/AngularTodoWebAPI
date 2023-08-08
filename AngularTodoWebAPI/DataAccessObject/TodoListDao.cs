using AngularTodoWebAPI.DataTransferObject;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace AngularTodoWebAPI.DataAccessObject
{
    public class TodoListDao
    {
        private readonly TodoContext _dbContext;
        private readonly ILogger _logger;

        public TodoListDao(TodoContext dbContext, ILogger logger)
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
                }).OrderBy(x => x.TodoId).ToListAsync();

                return todoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
