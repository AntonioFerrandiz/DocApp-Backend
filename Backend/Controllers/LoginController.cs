using Backend.Domain.IServices;
using Backend.Domain.Models;
using Backend.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IConfiguration _config;
        public LoginController(ILoginService loginService, IConfiguration configuration)
        {
            _loginService = loginService;
            _config = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                user.Password = Encrypt.EncryptPassword(user.Password);
                var userV = await _loginService.ValidateUser(user);
                if (userV == null)
                {
                    return BadRequest(new { message = "Incorrect data." });
                }
                string tokenString = JwtConfigurator.GetToken(userV, _config);
                return Ok(new { token = tokenString });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetUserData")]
        [HttpGet]
        public async Task<IActionResult> GetUserData()
        {
            try
            {
                //var identity = HttpContext.User.Identity as ClaimsIdentity;
                //int userID = JwtConfigurator.GetTokenUserID(identity);
                var userData = await _loginService.GetUserdata(1);
                return Ok(userData);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
