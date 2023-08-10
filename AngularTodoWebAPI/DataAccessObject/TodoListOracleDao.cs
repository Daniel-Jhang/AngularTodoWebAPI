namespace AngularTodoWebAPI.DataAccessObject
{
    public class TodoListOracleDao : ITodoListDao
    {
        public Task<TodoListDto> CreateTodoRecord(TodoListDto newTodo)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoListDto>> DeleteTodoRecord(Guid todoRecordId)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoListDto>> GetAllTodoList()
        {
            throw new NotImplementedException();
        }

        public Task<TodoList> GetTodoRecordByContext(string context)
        {
            throw new NotImplementedException();
        }

        public Task<TodoList> GetTodoRecordById(Guid todoRecordId)
        {
            throw new NotImplementedException();
        }

        public Task<TodoListDto> UpdateTodoRecord(TodoListDto todoRecord)
        {
            throw new NotImplementedException();
        }
    }
}
