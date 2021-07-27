using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalShelter.Application.Animals.Queries
{
    public class GetAnimalRequest : IRequest<Animal>
    {
        public int ShelterNumber { get; set; }


        public class Handler : IRequestHandler<GetAnimalRequest, Animal>
        {
            private readonly IAnimalShelterDbContext _context;

            public Handler(IAnimalShelterDbContext context)
            {
                _context = context;
            }

            public async Task<Animal> Handle(GetAnimalRequest request, CancellationToken cancellationToken)
            {
                var animal = await _context.Animals.FirstOrDefaultAsync(a => a.ShelterNumber == request.ShelterNumber);
                return animal;
            }
        }

    }
}
