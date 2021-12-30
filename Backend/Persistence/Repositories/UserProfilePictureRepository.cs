using Backend.Domain.IRepositories;
using Backend.Domain.Models;
using Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Persistence.Repositories
{
    public class UserProfilePictureRepository: IUserProfilePictureRepository
    {
        private readonly AplicationDbContext _context;
        public UserProfilePictureRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserProfilePicture>> GetProfileImageURL(int userID)
        {
            var getProfileImageURL = await _context.UserProfilePictures
                .Where(x => x.UserID == userID)
                .ToListAsync();
            return getProfileImageURL;
        }

        public async Task SaveProfileImageURL(UserProfilePicture userProfilePicture)
        {
            _context.Add(userProfilePicture);
            await _context.SaveChangesAsync();
        }
    }
}
