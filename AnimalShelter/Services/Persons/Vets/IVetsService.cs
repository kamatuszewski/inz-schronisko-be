using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services
{
    public interface IVetsService
    {
        //dodawanie i usuwanie jest zaimplementowane poprzez nadawanie i odbieranie roli

        public IEnumerable<GeneralVetResponse> GetVets();
        public DetailedVetResponse GetVet(int id);
        public void AddSpecialtyToVet(int VetId, AddSpecialtyToVetRequest addSpecialtyToVetRequest);
        public void RemoveSpecialtyFromVet(int VetId, int SpecialtyId);

        public IEnumerable<SpecialtyResponse> GetSpecialties();
        public Specialty CreateSpecialty(CreateSpecialtyRequest createSpecialtyRequest);
        void RemoveSpecialty(int id);
    }
}
