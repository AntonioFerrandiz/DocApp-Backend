using Backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Domain.IServices
{
    public interface IUserService
    {
        Task SaveUser(User user);
        Task<bool> ValidateUsernameExistence(User user);
        Task<bool> ValidateEmailExistence(User user);
        Task<bool> ValidateIdentityDocumentExistence(User user);
    }
}
