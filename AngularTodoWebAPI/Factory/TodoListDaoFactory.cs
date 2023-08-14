namespace AngularTodoWebAPI.Factory
{
    public class TodoListDaoFactory<TDao> : ITodoListDaoFactory where TDao : ITodoListDao
    {
        private readonly IServiceProvider _serviceProvider;

        public TodoListDaoFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITodoListDao Create()
        {
            return _serviceProvider.GetRequiredService<TDao>();
        }
    }
}
