using Beauty.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Beauty.Shared.Requests;
using Beauty.API.ViewModels;
using Beauty.API.Responses;

namespace Beauty.API.Controllers {
    [Route("/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        public IUserService _userService;
        public AuthController(IUserService userService)
            => _userService = userService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModelRequest registrationModel) {
            if (ModelState.IsValid && registrationModel.Role is not "Admin") {
                var result = await _userService.Register(registrationModel);
                if (result.IsSuccess)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Fields not valid");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModelRequest loginModel) {
            if (ModelState.IsValid) {
                var result = await _userService.Login(loginModel);
                if (result.IsSuccess)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Fields not valid");
        }

        [HttpGet("forget/{email}")]
        public async Task<IActionResult> ForgetPassword([FromRoute]string email) {
            if (email is not null) {
                var result = await _userService.ForgetPassword(email);
                if (result.IsSuccess)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Data null");
        }

        [HttpPost("reset/{Email}/{Token}")]
        public async Task<IActionResult> ResetPassword([FromForm]ResetPasswordVM resetPasswordVM, [FromRoute]string Email, [FromRoute]string Token) {
            if (ModelState.IsValid) {
                resetPasswordVM.Email = Email;
                resetPasswordVM.Token = Token;
                var result = await _userService.ResetPassword(resetPasswordVM);
                if (result.IsSuccess)
                    return Ok(result.Message);
                return BadRequest(result.Message);
            }
            return BadRequest("Error data");
        }
    }
}