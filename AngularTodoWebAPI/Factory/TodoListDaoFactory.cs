namespace AngularTodoWebAPI.Factory
{
    public class TodoListMSSQLDaoFactory : ITodoListDaoFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TodoListMSSQLDaoFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITodoListDao Create()
        {
            return _serviceProvider.GetRequiredService<TodoListMSSQLDao>();
        }
    }

    public class TodoListOracleDaoFactory : ITodoListDaoFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public TodoListOracleDaoFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ITodoListDao Create()
        {
            return _serviceProvider.GetRequiredService<TodoListOracleDao>();
        }
    }
}
