using Bz.F8t.Administration.Application.Common;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Bz.F8t.Administration.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        var applicationAssembly = typeof(Application.Common.IUnitOfWork).Assembly;
        var domainAssembly = typeof(Domain.Common.IDomainEvent).Assembly;

        return service
            .AddMediatR(c =>
            { 
                c.RegisterServicesFromAssemblies(
                    applicationAssembly,
                    domainAssembly);

                c.AddOpenBehavior(typeof(ValidationBehavior<,>));
            })
            .AddApplicationServices()
            .AddAutoMapper(applicationAssembly)
            .AddValidatorsFromAssembly(applicationAssembly);
    }

    private static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services
            .Scan(scan => scan.FromAssemblyOf<IApplicationService>()
            .AddClasses(classes => classes.AssignableTo<IApplicationService>())
            .AsMatchingInterface()
            .WithScopedLifetime());
    }
}
