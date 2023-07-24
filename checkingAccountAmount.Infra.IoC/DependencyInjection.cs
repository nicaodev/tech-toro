using checkingAccountAmount.Application.Interfaces;
using checkingAccountAmount.Application.Services;
using checkingAccountAmount.Domain.Interfaces;
using checkingAccountAmount.Infra.Data.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace checkingAccountAmount.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICheckingAccountAmountRepository, CheckingAccountAmountRepository>();
        services.AddScoped<ICheckingAccountAmountService, CheckingAccountAmountService>();

        return services;
    }
}