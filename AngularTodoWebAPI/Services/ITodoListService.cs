namespace AngularTodoWebAPI.Services
{
    public interface ITodoListService
    {
        Task<TodoListDto> CreateTodoRecord(TodoListDto todoRecord);
        Task<List<TodoListDto>> DeleteProduct(Guid productId);
        Task<List<TodoListDto>> GetAllTodoList();
        Task<TodoListDto> UpdateProduct(TodoListDto todoRecord);
    }
}