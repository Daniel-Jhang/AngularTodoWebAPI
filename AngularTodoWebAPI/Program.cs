using Microsoft.Extensions.Configuration;

try
{
    var builder = WebApplication.CreateBuilder(args);

    #region Configure
    builder.Host.ConfigureAppConfiguration((hostContext, config) =>
    {
        var env = hostContext.HostingEnvironment;
        config.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
          .AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true)
          .AddJsonFile(path: $"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true); ;
    })
        .UseSerilog((hostingContext, loggerConfig) =>
         loggerConfig.ReadFrom.Configuration(hostingContext.Configuration).Enrich.FromLogContext()
         );

    var config = builder.Configuration;

    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();
    #endregion

    #region DataBase
    // EF Core
    builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(config.GetConnectionString("TODOConnection_MSSQL")));
    builder.Services.AddScoped<ITodoListDaoFactory, TodoListDaoFactory<TodoListMSSQLEFCoreDao>>();
    builder.Services.AddScoped<TodoListMSSQLEFCoreDao>();

    //builder.Services.AddDbContext<DataContext>(options => options.UseOracle(config.GetConnectionString("TODOConnection_Oracle")));
    //builder.Services.AddScoped<ITodoListDaoFactory, TodoListDaoFactory<TodoListOracleEFCoreDao>>();
    //builder.Services.AddScoped<TodoListOracleEFCoreDao>();


    // Dapper
    builder.Services.AddScoped<ICustomConnectionFactory>(_ => new CustomConnectionFactory(() => config.GetConnectionString("TODOConnection_MSSQL")));
    #endregion

    // Add services to the container.

    builder.Services.AddScoped<ITodoListService, TodoListService>();


    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}