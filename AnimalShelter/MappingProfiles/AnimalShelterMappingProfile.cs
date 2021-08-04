using AnimalShelter.DTOs.Responses;
using AnimalShelter.Models;
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
            CreateMap<Animal, AnimalResponse>()
                .ForMember(m => m.Species, c => c.MapFrom(s => s.Species.Name))
                .ForMember(m => m.Status, c => c.MapFrom(s => s.Status.Name));

            CreateMap<Person, PersonResponse>();


            //tutaj moge dodac kolejne mapy CreateMap
        }
    }
}
