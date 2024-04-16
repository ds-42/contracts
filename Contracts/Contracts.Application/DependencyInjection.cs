using Contracts.Application.Cashes;
using Microsoft.Extensions.DependencyInjection;

namespace Contracts.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUserApplication(this IServiceCollection services)
    {
        return services
/*            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true)**/
            .AddSingleton<ContractsMemoryCache>();
    }
}