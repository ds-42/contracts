using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text.Json.Serialization;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;
using Core.Api.JsonSerializer;

namespace Core.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreApiServices(this IServiceCollection services)
    {
        return services
            .AddHttpContextAccessor()
            .Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.Converters.Add(new TrimmingConverter());
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            })
            .AddResponseCompression(options => { options.EnableForHttps = true; });
    }

    public static IHostBuilder UseApiLogger(this IHostBuilder host, IConfiguration configuration) 
    {
        return host.UseSerilog((ctx, lc) => lc
#if DEBUG
            .WriteTo.Console()
#endif
            .WriteTo.File($"{configuration["Logging:LogsFolder"]}/Information-.txt", LogEventLevel.Information,
                rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3, buffered: true)
            .WriteTo.File($"{configuration["Logging:LogsFolder"]}/Warning-.txt", LogEventLevel.Warning,
                rollingInterval: RollingInterval.Day, retainedFileCountLimit: 14, buffered: true)
            .WriteTo.File($"{configuration["Logging:LogsFolder"]}/Error-.txt", LogEventLevel.Error,
                rollingInterval: RollingInterval.Day, retainedFileCountLimit: 30, buffered: true));
    }

public static IServiceCollection AddAllCors(this IServiceCollection services)
{
    return services
        .AddCors(options =>
        {
            options.AddPolicy(CorsPolicy.AllowAll, policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
                policy.WithExposedHeaders("*");
            });
        });
}
        
/*    public static IServiceCollection AddSwagger(
        this IServiceCollection services,
        Assembly apiAssembly,
        string appName,
        string version,
        string description)
    {
        return services.AddEndpointsApiExplorer()
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Version = version,
                    Title = appName,
                    Description = description
                });
                    
                // using System.Reflection;
                var xmlFilename = $"{apiAssembly.GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
    }*/
}