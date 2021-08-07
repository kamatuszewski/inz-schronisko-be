using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.Responses.AnimalResponses;
using AnimalShelter_WebAPI.DTOs.VetVisit.Responses;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.MappingProfiles
{
    public class AnimalShelterMappingProfile : Profile
    {
        public AnimalShelterMappingProfile()
        { 
            CreateMap<Animal, GeneralAnimalResponse>()
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species.Name))
                .ForMember(m => m.Status, c => c.MapFrom(s => s.Status.Name));

            CreateMap<Animal, DetailedAnimalResponse>()
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species.Name))
                .ForMember(m => m.Status, c => c.MapFrom(s => s.Status.Name));


            CreateMap<Person, AdopterResponse>();
            CreateMap<Person, PersonResponse>();
            CreateMap<Person, EmployeeResponse>();

            CreateMap<Adoption, AdoptionResponse>();


            CreateMap<VetVisit, GeneralVetVisitResponse>();


            CreateMap<CreatePersonRequest, Person>();
            CreateMap<CreateAnimalRequest, Animal>();
        }
    }
}
