using Contracts.Application;
using Core.Api;
using Core.Api.Middlewares;
using Core.Application;
using Core.Auth.Api;
using Core.Auth.Application;
using Infrastructure.Persistence;
using System.Reflection;

try 
{
    const string version = "v1";
    const string appName = $"Contracts API {version}";

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseApiLogger(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services
        .AddSwaggerWidthJwtAuth(Assembly.GetExecutingAssembly(), appName, version, appName)
        .AddCoreApiServices(builder.Configuration)
        .AddCoreApplicationServices()
        .AddCoreAuthApiServices(builder.Configuration)
        .AddPersistenceServices(builder.Configuration)
        .AddCoreAuthServices()
        .AddAllCors()
        .AddContractsApplication()
        .AddEndpointsApiExplorer();

    var app = builder.Build();

//    app.RunDbMigrations().RegisterApis(Assembly.GetExecutingAssembly(), $"api/{version}");

    app.UseCoreExceptionHandler();
//    if (app.Environment.IsDevelopment())
//    {
        app.UseSwagger();
        app.UseSwaggerUI();
//    }

    app.UseAuthentication();

    app.UseAuthorization();

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    CoreApi.FatalException(ex);
}
