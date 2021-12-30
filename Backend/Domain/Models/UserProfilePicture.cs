using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.Models
{
    public class UserProfilePicture
    {
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
