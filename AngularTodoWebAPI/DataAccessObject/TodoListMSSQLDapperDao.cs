namespace AngularTodoWebAPI.DataAccessObject
{
    public class TodoListMSSQLDapperDao : ITodoListDao
    {
        public Task<TodoListDto> CreateTodoRecord(TodoListDto newTodo)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoListDto>> GetAllTodoList()
        {
            throw new NotImplementedException();
        }

        public Task<TodoListDto> GetTodoRecord(Guid? todoRecordId = null, string? context = null)
        {
            throw new NotImplementedException();
        }

        public Task<TodoListDto> UpdateTodoRecord(TodoListDto todoRecord)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoListDto>> DeleteTodoRecord(Guid todoRecordId)
        {
            throw new NotImplementedException();
        }
    }
}
