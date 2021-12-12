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

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Details { get; set; }

        public DateTime DateCreated { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }
    }
}
