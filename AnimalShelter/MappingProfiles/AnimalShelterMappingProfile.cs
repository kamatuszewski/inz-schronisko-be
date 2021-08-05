using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.Requests;
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

            CreateMap<Person, PersonResponse>();

            CreateMap<CreatePersonRequest, Person>();

            CreateMap<CreateAdopterRequest, Adopter>()
                .ForMember(m => m.Person, c => c.MapFrom(dto => new Person() 
                { FirstName = dto.FirstName, LastName = dto.LastName, PESEL = dto.PESEL, Sex = dto.Sex, ContactInfo = dto.ContactInfo}));

            // czy front moze mi zwracac numerek?
            //     CreateMap<CreateAnimalRequest, Animal>()
            //       .ForMember(m => m.Species.Name, c => c.MapFrom(s => s.Species));


        }
    }
}
