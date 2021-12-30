using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IUserProfilePictureService
    {
        Task SaveProfileImageURL(UserProfilePicture userProfilePicture);
        Task<List<UserProfilePicture>> GetProfileImageURL(int userID);
    }
}
