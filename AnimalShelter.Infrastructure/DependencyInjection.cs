using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AnimalShelter.Application.Interfaces;
using AnimalShelter.Infrastructure.Models;

namespace AnimalShelter.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAnimalShelterDbContext, AnimalShelterDbContext>();
            //TODO adding other Infrastructure layer dependencies

            return services;
        }
    }
}
