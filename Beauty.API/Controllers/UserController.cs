namespace Beauty.API.Controllers;
[Route("/[controller]/[action]")]
[Authorize]
[ApiController]
public class UserController : ControllerBase {
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly ApplicationDbContext _db;
    public UserController(UserManager<User> userManager, ApplicationDbContext db, IUserService userService) {
        _userManager = userManager;
        _db = db;
        _userService = userService;
    }
    public async Task<ActionResult<UserResponse>> GetUser() {
        string accessToken = await HttpContext.GetTokenAsync("access_token");
        string id = new TokenHelper(accessToken).GetNameIdentifer(); //Select(c => new{ c.Id, c.Email, c.PhoneNumber, c.UserName, c.Photo })
        User user = await _db.Users.SingleOrDefaultAsync(record => record.Id == id);
        if (user is null)
            return BadRequest("Not User");
        UserResponse userResponse = AutoMaperHelper<User, UserResponse>.GetDestination(user);
        userResponse.Email = await _userManager.GetEmailAsync(user);
        return Ok(userResponse);
    }
    [HttpPost]
    public async Task<IActionResult> UpdateUser([FromBody] UserRequest userRequest) {
        if (userRequest is null)
            return BadRequest("Data is null");
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        TokenHelper tokenHelper = new (accessToken);
        var id = tokenHelper.GetNameIdentifer();
        var email = tokenHelper.GetEmail();
        User user = await _db.Users.SingleOrDefaultAsync(c => c.Id == id);
        if (user is null)
            return BadRequest("User null");
        var result = await _userService.Login(new LoginModelRequest() { Email = email, Password = userRequest.CurrentPassword });
        if (!result.IsSuccess)
            return BadRequest("Password Invalid");
        if (userRequest.NewPassword != null)
            await _userManager.ChangePasswordAsync(user, userRequest.CurrentPassword, userRequest.NewPassword);
        if (userRequest.Email != null) {
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
}