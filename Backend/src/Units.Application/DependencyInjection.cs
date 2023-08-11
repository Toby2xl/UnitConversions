using System;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Units.Application.Service;

namespace Units.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;

        services.AddMediatR(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped<IConversionService, ConversionService>();
        return services;
    }
}
