using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class BaseEntity
    {

        public int Id { get; set; }

        public DateTime EntryDate { get; set; }

        public DateTime UpdateTime { get; set; }

        public bool IsActive { get; set; }

    }
}
