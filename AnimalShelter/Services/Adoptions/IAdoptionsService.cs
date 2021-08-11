using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.Adoptions
{
    public interface IAdoptionsService
    {
        public IEnumerable<DetailedAdoptionResponse> GetAdoptions();
    }
}
