using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class UserProfilePictureService: IUserProfilePictureService
    {
        private readonly IUserProfilePictureRepository _userProfilePictureRepository;
        public UserProfilePictureService(IUserProfilePictureRepository userProfilePictureRepository)
        {
            _userProfilePictureRepository = userProfilePictureRepository;
        }

        public async Task<List<UserProfilePicture>> GetProfileImageURL(int userID)
        {
            return await _userProfilePictureRepository.GetProfileImageURL(userID);
        }


        public async Task SaveProfileImageURL(UserProfilePicture userProfilePicture)
        {
            await _userProfilePictureRepository.SaveProfileImageURL(userProfilePicture);
        }
    }
}
