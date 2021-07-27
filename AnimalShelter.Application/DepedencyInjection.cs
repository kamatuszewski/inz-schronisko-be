using MediatR;
using Microsoft.Extensions.DependencyInjection;
using AnimalShelter.Application.Common.Behaviours;
using System.Reflection;

namespace AnimalShelter.Application
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //TODO Adding other application layer dependencies

            return services;
        }
    }
}
