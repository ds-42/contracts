using Contracts.Application.Cashes;
using Contracts.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contracts.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddContractsApplication(this IServiceCollection services)
    {
        return services
            .AddSingleton<AddressMemoryCache>()
            .AddSingleton<ContractMemoryCache>()
            .AddSingleton<CurrencyMemoryCache>()
            .AddSingleton<DocumentMemoryCache>()
            .AddSingleton<EmployeeMemoryCache>()
            .AddSingleton<FormatMemoryCache>()
            .AddSingleton<FormatTypeMemoryCache>()
            .AddSingleton<OrgMemoryCache>()
            .AddSingleton<OwnershipMemoryCache>()

            .AddTransient<AddressService>()
            .AddTransient<СontractorService>()
            .AddTransient<DocumentService>()

            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}