using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IRepositories
{
    public interface IUserProfilePictureRepository
    {

        Task SaveProfileImageURL(UserProfilePicture userProfilePicture);
        Task<List<UserProfilePicture>> GetProfileImageURL(int userID);
    }
}
