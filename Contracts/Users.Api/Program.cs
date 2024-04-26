using Core.Api;
using Core.Auth.Api;
using Users.Application;
using Infrastructure.Persistence;
using System.Reflection;

try
{
/*    const string appPrefix = "UM";
    const string version = "v1";
    const string appName = "Users management API v1";*/

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseApiLogger(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services
//        .AddSwaggerWidthJwtAuth(Assembly.GetExecutingAssembly(), appName, version, appName)
        .AddSwaggerGen()
        .AddUsersApplication()
        .AddCoreApiServices()
        .AddCoreAuthApiServices(builder.Configuration)
        .AddPersistenceServices(builder.Configuration)
        .AddEndpointsApiExplorer();

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
    CoreApi.FatalException(ex);
}