using Auth.Application;
using Core.Api;
using Core.Auth.Api;
using Infrastructure.Persistence;

try 
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseApiLogger(builder.Configuration);

    builder.Services.AddControllers();
    builder.Services
        .AddAuthApplication()
        .AddCoreApiServices(builder.Configuration)
        .AddCoreAuthApiServices(builder.Configuration)
        .AddPersistenceServices(builder.Configuration)
        .AddEndpointsApiExplorer()
        .AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
//    if (app.Environment.IsDevelopment())
//    {
        app.UseSwagger();
        app.UseSwaggerUI();
//    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    CoreApi.FatalException(ex);
}
