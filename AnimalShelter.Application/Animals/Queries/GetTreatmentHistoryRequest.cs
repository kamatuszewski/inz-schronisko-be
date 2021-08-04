using AnimalShelter.Application.Interfaces;
using AnimalShelter.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AnimalShelter.Application.Animals.Queries
{
    public class GetTreatmentHistoryRequest : IRequest<Animal>
    {
        public int ShelterNumber { get; set; }


        public class Handler : IRequestHandler<GetTreatmentHistoryRequest, PerformedTreatment>
        {
            private readonly IAnimalShelterDbContext _context;

            public Handler(IAnimalShelterDbContext context)
            {
                _context = context;
            }

            public async Task<PerformedTreatment> Handle(GetTreatmentHistoryRequest request, CancellationToken cancellationToken)
            {
              //  var animal = await _context.PerformedTreatments.Where(a => a.IdVisit == request.ShelterNumber);
                return animal;
            }
        }

    }
}
