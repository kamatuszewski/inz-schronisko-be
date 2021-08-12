using AnimalShelter.Models;
using AnimalShelter_WebAPI.DTOs.VetVisitDetails;
using AnimalShelter_WebAPI.Exceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.Services.VetVisitsDetails
{
    public class MedicinesService : IMedicinesService
    {
        private readonly ShelterDbContext _context;
        private readonly IMapper _mapper;
        public MedicinesService(ShelterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Medicine CreateMedicine(CreateMedicineRequest createMedicineRequest)
        {
            var medicine = _mapper.Map<Medicine>(createMedicineRequest);
            _context.Medicine.Add(medicine);
            _context.SaveChanges();
            return medicine;
        }

        public IEnumerable<MedicinesResponse> GetMedicines()
        {
            var medicines = _context.Medicine
                .ToList();
            return _mapper.Map<IEnumerable<MedicinesResponse>>(medicines);
        }

        public void RemoveMedicine(int id)
        {
            var medicine = _context.Medicine.Where(a => a.Id == id)
               .FirstOrDefault();

            if (medicine is null)
                throw new NotFoundException("MEDICINE_NOT_FOUND");

            _context.Medicine.Remove(medicine);
            _context.SaveChanges();

        }
    }
}
