using Backend.Domain.IServices;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfilePictureController : ControllerBase
    {
        private readonly IUserProfilePictureService _userProfilePictureService;
        public UserProfilePictureController(IUserProfilePictureService userProfilePictureService)
        {
            _userProfilePictureService = userProfilePictureService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserProfilePicture userProfilePicture)
        {
            try
            {
                await _userProfilePictureService.SaveProfileImageURL(userProfilePicture);
                return Ok(new { message = "Profile picturre successfully added" });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return BadRequest(ex.Message);
            }
        }
        [Route("GetProfileImageURL")]
        [HttpGet]
        public async Task<IActionResult> GetProfileImageURL()
        {
            try
            {
                int userID = 1;
                var profileImageURL = await _userProfilePictureService.GetProfileImageURL(userID);
                return Ok(profileImageURL);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
