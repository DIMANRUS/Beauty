namespace Beauty.API.Controllers;
[Route("/[controller]")]
[ApiController]
public class AuthController : ControllerBase {
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
        => _userService = userService;

    [HttpGet]
    public int Get() => 5;

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationModelRequest registrationModel) {
        if (ModelState.IsValid && registrationModel.Role != "ADMIN") {
            var result = await _userService.Register(registrationModel);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        return BadRequest("Fields not valid");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModelRequest loginModel) {
        var result = await _userService.Login(loginModel);
        if (result.IsSuccess)
            return Ok(result.Message);
        return BadRequest(result.Message);
    }

    [HttpGet("forget/{email}")]
    public async Task<IActionResult> ForgetPassword([FromRoute] string email) {
        if (email is not null) {
            var result = await _userService.ForgetPassword(email);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        return BadRequest("Data null");
    }

    [HttpPost("reset/{email}/{token}")]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordVm resetPasswordVm, [FromRoute] string email, [FromRoute] string token) {
        if (ModelState.IsValid) {
            resetPasswordVm.Email = email;
            resetPasswordVm.Token = token;
            var result = await _userService.ResetPassword(resetPasswordVm);
            if (result.IsSuccess)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
        return BadRequest("Error data");
    }
}