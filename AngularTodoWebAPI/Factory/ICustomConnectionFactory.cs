namespace AngularTodoWebAPI.Factory
{
    public interface ICustomConnectionFactory
    {
        IDbConnection sqlConnection { get; }

        IDbConnection CreateConnection();
    }
}