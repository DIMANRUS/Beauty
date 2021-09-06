using Beauty.EFDataAccessLibrary.Contexts;
using Beauty.EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Beauty.Shared.Responses;
using Microsoft.AspNetCore.Authentication;
using Beauty.Shared.Helpers;
using Beauty.Shared.Requests;
using Beauty.API.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Beauty.API.Controllers {
    [Route("/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase {
        private UserManager<User> _userManager;
        private IUserService _userService;
        private ApplicationDbContext _db;
        public UserController(UserManager<User> userManager, ApplicationDbContext db, IUserService userService) {
            _userManager = userManager;
            _db = db;
            _userService = userService;
        }
        public async Task<ActionResult<UserResponse>> GetUser() {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var id = new TokenHelper(accessToken).GetNameIdentifer(); //Select(c => new{ c.Id, c.Email, c.PhoneNumber, c.UserName, c.Photo })
            var user = await _db.Users.SingleOrDefaultAsync(record => record.Id == id);
            if (user is not null)
            {
                UserResponse userResponse = AutoMaperHelper<User, UserResponse>.GetDestination(user);
                userResponse.Email = await _userManager.GetEmailAsync(user);
                return Ok(userResponse);
            }
            return BadRequest("Not User");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequest userRequest) {
            if (userRequest is not null)
            {
                var accessToken = await HttpContext.GetTokenAsync("access_token");
                TokenHelper tokenHelper = new TokenHelper(accessToken);
                var id = tokenHelper.GetNameIdentifer();
                var email = tokenHelper.GetEmail();
                User user = await _db.Users.SingleOrDefaultAsync(c => c.Id == id);
                if (user is not null)
                {
                    var result = await _userService.Login(new LoginModelRequest() { Email = email, Password = userRequest.CurrentPassword });
                    if (result.IsSuccess)
                    {
                        if (userRequest.NewPassword != null)
                            await _userManager.ChangePasswordAsync(user,userRequest.CurrentPassword, userRequest.NewPassword);
                        if (userRequest.Email != null)
                        {
                            string tokenChangeEmail = await _userManager.GenerateChangeEmailTokenAsync(user, userRequest.Email);
                            await _userManager.ChangeEmailAsync(user, userRequest.Email, tokenChangeEmail);
                        }
                        if (userRequest.PhoneNumber != null)
                            user.PhoneNumber = userRequest.PhoneNumber;
                        if (userRequest.Photo != null)
                            user.Photo = userRequest.Photo;
                        await _db.SaveChangesAsync();
                        return Ok("Success");
                    }
                    return BadRequest("Password Invalid");
                }
                return BadRequest("User null");
            }
            return BadRequest("Data is null");
        }
    }
}