using Bz.F8t.Administration.Application.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Bz.F8t.Administration.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        return service
            .AddMediatR(c => c.RegisterServicesFromAssemblies(
                typeof(Application.Common.IUnitOfWork).Assembly,
                typeof(Domain.Common.IDomainEvent).Assembly))
            .AddApplicationServices()
            .AddAutoMapper(Assembly.GetExecutingAssembly())
            .AddValidators();
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .Scan(scan => scan.FromAssemblyOf<IApplicationService>()
            .AddClasses(classes => classes.AssignableTo<IApplicationService>())
            .AsMatchingInterface()
            .WithScopedLifetime());
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        //services
        //    .AddScoped<IValidatorFactory, ValidatorFactory>();

        services
            .Scan(scan => scan.FromAssemblyOf<IApplicationService>()
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces(i => i.Name.StartsWith("IValidator") && i.IsGenericType)
            .WithScopedLifetime());

        return services;
    }
}
