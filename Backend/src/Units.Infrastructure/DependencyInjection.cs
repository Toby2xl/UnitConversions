using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Units.Application.Repository;
using Units.Infrastructure.Repository;


namespace Units.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connString = config.GetConnectionString("UnitsConversionDb");
        // services.AddDbContext<InventoryDbContext>(
        //     options => options.UseNpgsql(connString)
        // );

        services.AddScoped<IConversionRepo, ConversionRepo>();

        return services;
    }
}

