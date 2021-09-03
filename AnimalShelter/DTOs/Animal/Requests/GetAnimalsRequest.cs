using AnimalShelter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter_WebAPI.DTOs.Requests
{
    public class GetAnimalsRequest
    {
       
        public string Species { get; set; }
        public int? ChipNumber { get; set; }
        public string Status { get; set; }
        [Required]
        public int pageNumber { get; set; }
        [Required]
        public int pageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }

    }
}
