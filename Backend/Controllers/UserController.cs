using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                var validateExistenceU = await _userService.ValidateUsernameExistence(user);
                if (validateExistenceU)
                {
                    return BadRequest(new { message = "The username " + user.Username + "  is already in use" });
                }

                var validateExistenceE = await _userService.ValidateEmailExistence(user);
                if (validateExistenceE)
                {
                    return BadRequest(new { message = "The email " + user.Email + "  is already in use" });
                }

                var validateExistenceI = await _userService.ValidateIdentityDocumentExistence(user);
                if (validateExistenceI)
                {
                    return BadRequest(new { message = "The identity document " + user.IdentityDocument+ "  has already been registered" });
                }
                user.Password = Encrypt.EncryptPassword(user.Password);
                await _userService.SaveUser(user);
                return Ok(new { message = "Usuario registrado con exito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
