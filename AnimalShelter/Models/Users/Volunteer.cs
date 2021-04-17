﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class Volunteer
    {
        public int IdVolunteer { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Attendance { get; set; }


        public virtual Person Person { get; set; }
    }

}
