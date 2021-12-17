using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Firstname { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Lastname { get; set; }

        [Column(TypeName = "varchar(9)")]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }

        public int Active { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }


        public List<MedicalHistory> medicalHistories { get; set; }
    }
}
