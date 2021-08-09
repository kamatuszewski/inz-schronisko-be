using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
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
            //Animal mappings
            CreateMap<Animal, GeneralAnimalResponse>()
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species.Name))
                .ForMember(m => m.Status, c => c.MapFrom(s => s.Status.Name));

            CreateMap<Animal, DetailedAnimalResponse>()
               .ForMember(m => m.Species, c => c.MapFrom(s => s.Species.Name))
               .ForMember(m => m.Status, c => c.MapFrom(s => s.Status.Name));

            CreateMap<Animal, FullDataAnimalResponse>()
                .ForMember(m => m.DetailedAnimalResponse, c => c.MapFrom(s => s))
                .ForMember(m => m.VetVisitResponses, c => c.MapFrom(s => s.VetVisits))
                .ForMember(m => m.AdoptionResponses, c => c.MapFrom(s => s.Adoptions));

            CreateMap<Species, SpeciesResponse>();
            CreateMap<Status, StatusesResponse>();


            //FullDataAnimal mappings
            CreateMap<VetVisit, GeneralVetVisitResponse>();
            CreateMap<Adoption, AdoptionResponse>()
                .ForMember(m => m.AdopterResponse, c => c.MapFrom(s => s.Adopter))
                .ForMember(m => m.EmployeeResponse, c => c.MapFrom(ad => ad.Employee));
            CreateMap<Person, AdopterResponse>();
            CreateMap<Person, PersonResponse>();
            CreateMap<Employee, EmployeeResponse>()
             //   .ForMember(m => m.Id, c => c.MapFrom(a => a.Id))
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Person.LastName));


            //VetVisit mappings
            CreateMap<Medicine, MedicinesResponse>();
            CreateMap<Treatment, TreatmentsResponse>();

            CreateMap<CreateMedicineRequest, Medicine>();
            CreateMap<CreateTreatmentRequest, Treatment>();
            CreateMap<CreateVetVisitRequest, VetVisit>();

            //Vet mappings
            CreateMap<Specialty, SpecialtyResponse>();
            CreateMap<Specialty, ObtainedSpecialtyResponse>();
            CreateMap<Vet, GeneralVetResponse>()
            //    .ForMember(m => m.Id, c => c.MapFrom(a => a.Id))
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Employee.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Employee.Person.LastName));
            CreateMap<Vet, DetailedVetResponse>()
            //    .ForMember(m => m.Id, c => c.MapFrom(a => a.Id))
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Employee.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Employee.Person.LastName));
            CreateMap<CreateSpecialtyRequest, Specialty>();


            CreateMap<CreatePersonRequest, Person>();
            CreateMap<CreateAnimalRequest, Animal>();
        }
    }
}
