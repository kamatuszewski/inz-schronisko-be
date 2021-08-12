using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Animal.Responses;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Requests;
using AnimalShelter_WebAPI.DTOs.Person.Vet.Responses;
using AnimalShelter_WebAPI.DTOs.Requests;
using AnimalShelter_WebAPI.DTOs.Role.Responses;
using AnimalShelter_WebAPI.DTOs.Role;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalShelter_WebAPI.DTOs.Role.Requests;
using AnimalShelter_WebAPI.DTOs.Person;
using AnimalShelter_WebAPI.DTOs.Person.Employee.Responses;
using AnimalShelter_WebAPI.DTOs.Person.PersonsGeneral.Responses;
using AnimalShelter_WebAPI.DTOs.Adoption.Responses;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.VetVisits.Responses;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails.Medicines.Responses;

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
            CreateMap<CreateAnimalRequest, Animal>();

            //FullDataAnimal mappings
            CreateMap<VetVisit, GeneralVetVisitResponse>();
            CreateMap<Adoption, AdoptionResponse>()
                .ForMember(m => m.AdopterResponse, c => c.MapFrom(s => s.Adopter))
                .ForMember(m => m.EmployeeResponse, c => c.MapFrom(ad => ad.Employee));
            CreateMap<Person, AdopterResponse>();
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Person.LastName));

            //Adoption mappings
            CreateMap<Adoption, DetailedAdoptionResponse>()
                .ForMember(m => m.AdopterResponse, c => c.MapFrom(s => s.Adopter))
                .ForMember(m => m.EmployeeResponse, c => c.MapFrom(ad => ad.Employee))
                .ForMember(m => m.GeneralAnimalResponse, c => c.MapFrom(ad => ad.Animal));
            
            CreateMap<CreateAdoptionRequest, Adoption>();

            //VetVisit mappings

            CreateMap<VetVisit, VetVisitResponse>()
                .ForMember(m => m.prescribedMedicineResponses, c => c.MapFrom(v => v.PrescribedMedicines))
                .ForMember(m => m.treatmentsResponses, c => c.MapFrom(v => v.PerformedTreatments))
                .ForMember(m => m.generalAnimalResponse, c => c.MapFrom(v => v.Animal))
                .ForMember(m => m.generalVetResponse, c => c.MapFrom(v => v.Vet));
            
            CreateMap<Medicine, MedicinesResponse>();
            CreateMap<PrescribedMedicine, PrescribedMedicineResponse>()
                .ForMember(m => m.Name, c => c.MapFrom(m => m.Medicine.Name))
                .ForMember(m => m.Id, c => c.MapFrom(m => m.Medicine.Id))
                .ForMember(m => m.Amount, c => c.MapFrom(m => m.Amount));
            CreateMap<PerformedTreatment, TreatmentsResponse>()
                .ForMember(m => m.Name, c => c.MapFrom(m => m.Treatment.Name))
                .ForMember(m => m.Id, c => c.MapFrom(m => m.Treatment.Id));
            CreateMap<Treatment, TreatmentsResponse>();

            CreateMap<CreateMedicineRequest, Medicine>();
            CreateMap<CreateTreatmentRequest, Treatment>();
            CreateMap<CreateVetVisitRequest, VetVisit>();




            //Employee mappings
            CreateMap<Employee, GeneralEmployeeResponse>()
               .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Person.FirstName))
               .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Person.LastName))
               .ForMember(m => m.Sex, c => c.MapFrom(emp => emp.Person.Sex))
               .ForMember(m => m.roleResponses, c => c.MapFrom(p => p.Person.GrantedRoles))
               .ForMember(m => m.SpecialtyResponses, c => c.MapFrom(p => p.Vet.Vet_Specialties));
            CreateMap<Employee, DetailedEmployeeResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Person.LastName))
                .ForMember(m => m.Sex, c => c.MapFrom(emp => emp.Person.Sex))
                .ForMember(m => m.PESEL, c => c.MapFrom(emp => emp.Person.PESEL))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(emp => emp.Person.PhoneNumber))
                .ForMember(m => m.HireDate, c => c.MapFrom(emp => emp.HireDate))
                .ForMember(m => m.QuitDate, c => c.MapFrom(emp => emp.QuitDate))
                .ForMember(m => m.Salary, c => c.MapFrom(emp => emp.Salary))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(emp => emp.Person.EmailAddress))
                .ForMember(m => m.roleResponses, c => c.MapFrom(p => p.Person.GrantedRoles))
                .ForMember(m => m.PwzNumber, c => c.MapFrom(emp => emp.Vet.PWZNumber))
                .ForMember(m => m.SpecialtyResponses, c => c.MapFrom(e => e.Vet.Vet_Specialties));

            //Vet mappings
            CreateMap<Specialty, SpecialtyResponse>();
            CreateMap<Vet_Specialty, SpecialtyResponse>()
                .ForMember(m => m.Name, c => c.MapFrom(e => e.Specialty.Name))
                .ForMember(m => m.Id, c => c.MapFrom(emp => emp.Specialty.Id));
            CreateMap<Vet_Specialty, ObtainedSpecialtyResponse>()
                .ForMember(m => m.Name, c => c.MapFrom(e => e.Specialty.Name))
                .ForMember(m => m.Id, c => c.MapFrom(emp => emp.Specialty.Id));
            CreateMap<Vet, GeneralVetResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Employee.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Employee.Person.LastName))
                .ForMember(m => m.Sex, c => c.MapFrom(emp => emp.Employee.Person.Sex))
                .ForMember(m => m.SpecialtyResponses, c => c.MapFrom(e => e.Vet_Specialties));
            CreateMap<Vet, DetailedVetResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(emp => emp.Employee.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(emp => emp.Employee.Person.LastName))
                .ForMember(m => m.Sex, c => c.MapFrom(emp => emp.Employee.Person.Sex))
                .ForMember(m => m.PESEL, c => c.MapFrom(emp => emp.Employee.Person.PESEL))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(emp => emp.Employee.Person.PhoneNumber))
                .ForMember(m => m.HireDate, c => c.MapFrom(emp => emp.Employee.HireDate))
                .ForMember(m => m.QuitDate, c => c.MapFrom(emp => emp.Employee.QuitDate))
                .ForMember(m => m.Salary, c => c.MapFrom(emp => emp.Employee.Salary))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(emp => emp.Employee.Person.EmailAddress))
                .ForMember(m => m.SpecialtyResponses, c => c.MapFrom(e => e.Vet_Specialties));
            CreateMap<CreateSpecialtyRequest, Specialty>();
            CreateMap<AddSpecialtyToVetRequest, Vet_Specialty>();

            //Volunteer mappings
            CreateMap<Volunteer, GeneralVolunteerResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(v => v.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(v => v.Person.LastName))
                .ForMember(m => m.Sex, c => c.MapFrom(v => v.Person.Sex));

            CreateMap<Volunteer, DetailedVolunteerResponse>()
                .ForMember(m => m.FirstName, c => c.MapFrom(v => v.Person.FirstName))
                .ForMember(m => m.LastName, c => c.MapFrom(v => v.Person.LastName))
                .ForMember(m => m.Sex, c => c.MapFrom(v => v.Person.Sex))
                .ForMember(m => m.PESEL, c => c.MapFrom(v => v.Person.PESEL))
                .ForMember(m => m.PhoneNumber, c => c.MapFrom(v => v.Person.PhoneNumber))
                .ForMember(m => m.EmailAddress, c => c.MapFrom(v => v.Person.EmailAddress));
              


            //Token mapping
            CreateMap<Role, RoleResponse>();

            //People mapping
            CreateMap<CreatePersonRequest, Person>();

           
            CreateMap<RegisterPersonRequest, Volunteer>();
            CreateMap<RegisterPersonRequest, Employee>();
            CreateMap<RegisterPersonRequest, Vet>();

            //Roles
            CreateMap<Person, PersonResponse>()
               .ForMember(m => m.Roles, c => c.MapFrom(s => s.GrantedRoles));
            CreateMap<Person, GeneralPersonResponse>()
              .ForMember(m => m.Roles, c => c.MapFrom(s => s.GrantedRoles));
            CreateMap<GrantedRole, RoleResponse>()
                .ForMember(m => m.Id, c => c.MapFrom(r => r.RoleId))
                .ForMember(m => m.Name, c => c.MapFrom(r => r.Role.Name));
            CreateMap<AddRoleToPersonRequest, Volunteer>();
            CreateMap<AddRoleToPersonRequest, Employee>();
            CreateMap<AddRoleToPersonRequest, Vet>();


            CreateMap<RemoveRoleFromPersonRequest, Volunteer>();
            CreateMap<RemoveRoleFromPersonRequest, Employee>();
            CreateMap<RemoveRoleFromPersonRequest, Vet>();

            CreateMap<AddRoleToPersonRequest, GrantedRole>();
        }
    }
}