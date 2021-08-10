﻿using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.Role;
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
            //Animal endpoints mapping
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


            //FullDataAnimalResponse mappings
            CreateMap<VetVisit, GeneralVetVisitResponse>();
            CreateMap<Adoption, AdoptionResponse>()
                .ForMember(m => m.AdopterResponse, c => c.MapFrom(s => s.Adopter))
                .ForMember(m => m.EmployeeResponse, c => c.MapFrom(ad => ad.AdoptionOfficeWorker));
            CreateMap<Person, AdopterResponse>();
            CreateMap<Person, PersonResponse>();
            CreateMap<AdoptionOfficeWorker, EmployeeResponse>()
                .ForMember(m => m.Id, c => c.MapFrom(a => a.Id))
                .ForMember(m => m.FirstName, c => c.MapFrom(aow => aow.Employee.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(aow => aow.Employee.Person.LastName));


            //VetVisitResponses mappings
            CreateMap<Medicine, MedicinesResponse>();
            CreateMap<Treatment, TreatmentsResponse>();

            CreateMap<CreateMedicineRequest, Medicine>();
            CreateMap<CreateTreatmentRequest, Treatment>();
            CreateMap<CreateVetVisitRequest, VetVisit>();

            CreateMap<CreatePersonRequest, Person>();
            CreateMap<CreateAnimalRequest, Animal>();

            //People mapping
            CreateMap<RegisterPersonRequest, Volunteer>();
            CreateMap<RegisterPersonRequest, Employee>();
            CreateMap<RegisterPersonRequest, Vet>();

            CreateMap<AddRoleToPersonRequest, Volunteer>();
            CreateMap<AddRoleToPersonRequest, Employee>();
            CreateMap<AddRoleToPersonRequest, Vet>();

            CreateMap<AddRoleToPersonRequest, GrantedRole>();
        }
    }
}
