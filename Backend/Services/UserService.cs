using Backend.Domain.IRepositories;
using Backend.Domain.IServices;
using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task SaveUser(User user)
        {
            await _userRepository.SaveUser(user);
        }
        public async Task<bool> ValidateUsernameExistence(User user)
        {
            return await _userRepository.ValidateUsernameExistence(user);
        }
        public async Task<bool> ValidateEmailExistence(User user)
        {
            return await _userRepository.ValidateEmailExistence(user);
        }
        public async Task<bool> ValidateIdentityDocumentExistence(User user)
        {
            return await _userRepository.ValidateIdentityDocumentExistence(user);
        }
    }
}
