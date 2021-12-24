using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }

        public string Details { get; set; }

        public DateTime DateCreated { get; set; }

        public int Age { get; set; }
        public string TimePeriod { get; set; }
        public int Weight { get; set; }

        public int Height { get; set; }
        public string PrescribedMedication { get; set; }
        
        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }
}
