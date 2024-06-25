using Core.Api;
using Core.Application;
using Core.Auth.Api;
using Infrastructure.Persistence;
using System.Reflection;
using System;
using Users.Application;

try
{
    const string version = "v1";
    const string appName = "Users management API v1"; 

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseApiLogger(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services
        .AddSwaggerWidthJwtAuth(Assembly.GetExecutingAssembly(), appName, version, appName)
        .AddCoreApplicationServices()
        .AddUsersApplication(builder.Configuration)
        .AddCoreApiServices(builder.Configuration)
        .AddCoreAuthApiServices(builder.Configuration)
        .AddPersistenceServices(builder.Configuration)
        .AddEndpointsApiExplorer();


    var app = builder.Build();

    app.RunDbMigrations();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    CoreApi.FatalException(ex);
}