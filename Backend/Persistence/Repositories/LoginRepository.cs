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
    public class LoginRepository: ILoginRepository
    {
        private readonly AplicationDbContext _context;
        public LoginRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserdata(int userID)
        {
            var userData = await _context.Users
                .Where(x => x.Id == userID).FirstOrDefaultAsync();
            return userData;
        }

        public async Task<User> ValidateUser(User user)
        {
            var userL = await _context.Users
                .Where(x => x.Username == user.Username &&
                        x.IdentityDocument == user.IdentityDocument &&
                        x.Password == user.Password).FirstOrDefaultAsync();
            return userL;
        }
    }
}
