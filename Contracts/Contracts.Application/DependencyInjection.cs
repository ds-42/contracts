using Contracts.Application.Cashes;
using Contracts.Application.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Contracts.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddContractsApplication(this IServiceCollection services)
    {
        return services
            .AddTransient<AddressCache>()
            .AddTransient<ContractCache>()
            .AddTransient<CurrencyCache>()
            .AddTransient<DocumentCache>()
            .AddTransient<EmployeeCache>()
            .AddTransient<FormatCache>()
            .AddTransient<FormatTypeCache>()
            .AddTransient<OrgCache>()
            .AddTransient<OwnershipCache>()
            .AddTransient<PartnerCache>()

            .AddTransient<AddressService>()
            .AddTransient<СontractorService>()
            .AddTransient<DocumentService>()
            .AddTransient<OrgService>()

            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), includeInternalTypes: true);
    }
}