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
    public class UserRepository: IUserRepository
    {
        private readonly AplicationDbContext _context;
        public UserRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task SaveUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ValidateUsernameExistence(User user)
        {
            var validateExistence = await _context.Users.AnyAsync(x => x.Username == user.Username);
            return validateExistence;
        }

        public async Task<bool> ValidateIdentityDocumentExistence(User user)
        {
            var validateExistence = await _context.Users.AnyAsync(x => x.IdentityDocument == user.IdentityDocument);
            return validateExistence;
        }
        public async Task<bool> ValidateEmailExistence(User user)
        {
            var validateExistence = await _context.Users.AnyAsync(x => x.Email == user.Email);
            return validateExistence;
        }



    }
}
