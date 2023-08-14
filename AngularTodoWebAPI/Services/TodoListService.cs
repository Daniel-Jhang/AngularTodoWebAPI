namespace AngularTodoWebAPI.Services
{
    public class TodoListService : ITodoListService
    {
        //private readonly ITodoListDao _todoListDao;
        private readonly ITodoListDaoFactory _daoFactory;
        private ITodoListDao todoListDao;

        public TodoListService(/*ITodoListDao todoListDao,*/ ITodoListDaoFactory daoFactory)
        {
            //this._todoListDao = todoListDao;
            this._daoFactory = daoFactory;
            this.todoListDao = _daoFactory.Create(); // 根據應用程序的配置創建適當的實例
        }

        public async Task<TodoListDto> CreateTodoRecord(TodoListDto todoRecord)
        {


            // 使用 dao 進行操作
            var exitTodoRecord = await todoListDao.GetTodoRecord(context: todoRecord.Context);
            if (exitTodoRecord != null)
            {
                throw new Exception("紀錄重複");
            }
            var recordToCreate = await todoListDao.CreateTodoRecord(todoRecord);
            return recordToCreate;
        }

        public async Task<List<TodoListDto>> GetAllTodoList()
        {
            //return await _todoListDao.GetAllTodoList();
            return await todoListDao.GetAllTodoList();
        }

        public async Task<TodoListDto> UpdateProduct(TodoListDto todoRecord)
        {
            // Business Logic
            // var recordToUpdate = await _todoListDao.UpdateTodoRecord(todoRecord);
            var recordToUpdate = await todoListDao.UpdateTodoRecord(todoRecord);
            return recordToUpdate;
        }

        public async Task<List<TodoListDto>> DeleteProduct(Guid todoRecordId)
        {
            // Business Logic
            // var result = await _todoListDao.DeleteTodoRecord(todoRecordId);
            var result = await todoListDao.DeleteTodoRecord(todoRecordId);
            return result;
        }
    }
}