namespace AngularTodoWebAPI.Factory
{
    public class CustomConnectionFactory : ICustomConnectionFactory
    {
        private readonly Func<string> _getConnectionString;
        public IDbConnection sqlConnection { get; }

        public CustomConnectionFactory(Func<string> getConnectionString)
        {
            this._getConnectionString = getConnectionString ?? throw new ArgumentNullException(nameof(getConnectionString));
            sqlConnection = CreateConnection();
        }

        public IDbConnection CreateConnection() => new SqlConnection(_getConnectionString());
    }
}
