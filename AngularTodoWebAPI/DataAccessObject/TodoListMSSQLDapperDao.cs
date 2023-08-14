using AngularTodoWebAPI.Helper;
using Dapper;

namespace AngularTodoWebAPI.DataAccessObject
{
    public class TodoListMSSQLDapperDao : ITodoListDao
    {
        private readonly ILogger _logger;
        private readonly string _MsSqlDbString;

        public TodoListMSSQLDapperDao(ILogger logger, IConfiguration config)
        {
            this._logger = logger;
            this._MsSqlDbString = config.GetConnectionString("TODOConnection_MSSQL") ?? throw new Exception("資料庫連線字串設定讀取失敗");

            
        }

        public Task<TodoListDto> CreateTodoRecord(TodoListDto newTodo)
        {
            throw new NotImplementedException();
        }

        public Task<List<TodoListDto>> GetAllTodoList()
        {
            SqlConnection TodoDbConn = new SqlConnection(_MsSqlDbString);
            TodoDbConn.OpenAsync();
            string querySqlCommand = QueryStrings.GetAllTodoList;
            var result = TodoDbConn.Query<TodoListDto>(querySqlCommand).ToList();
      
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
