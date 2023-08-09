namespace AngularTodoWebAPI.DataAccessObject
{
    public interface ITodoListDao
    {
        Task<TodoListDto> CreateTodoRecord(TodoListDto newTodo);
        Task<List<TodoListDto>> DeleteTodoRecord(Guid todoRecordId);
        Task<List<TodoListDto>> GetAllTodoList();
        Task<TodoList> GetTodoRecordByContext(string context);
        Task<TodoList> GetTodoRecordById(Guid todoRecordId);
        Task<TodoListDto> UpdateTodoRecord(TodoListDto todoRecord);
    }
}