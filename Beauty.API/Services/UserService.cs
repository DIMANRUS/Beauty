namespace Beauty.API.Services;
public class UserService : IUserService {
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IConfiguration _config;
    private readonly IMailService _mailService;
    public UserService(UserManager<User> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext, IMailService mailService) {
        _userManager = userManager;
        _config = config;
        _roleManager = roleManager;
        _applicationDbContext = applicationDbContext;
        _mailService = mailService;
    }
    private async Task<string> GetToken(User user) {
        IList<string> role = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
        Claim[] claims = new[] {
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Role, role.First()),
                            new Claim(ClaimTypes.Name, user.UserName)
                        };

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["AuthSettings:Key"]));

        JwtSecurityToken token = new(
            issuer: _config["AuthSettings:Issuer"],
            audience: _config["AuthSettings:Audience"],
            expires: DateTime.Now.AddDays(50),
            claims: claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    public async Task<UserManagerResponse> Login(LoginModelRequest loginModel) {
        if (loginModel is null)
            return new UserManagerResponse() { IsSuccess = false, Message = "Model is null" };
        var user = await _userManager.FindByEmailAsync(loginModel.Email);
        if (user is null)
            return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
        bool resultPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);
        return resultPassword ? new UserManagerResponse { IsSuccess = true, Message = await GetToken(user) } : new UserManagerResponse() { IsSuccess = false, Message = "Password invalid" };
    }
    public async Task<UserManagerResponse> Register(RegistrationModelRequest registrationModel) {
        if (registrationModel is null)
            return new UserManagerResponse { IsSuccess = false, Message = "Model is null" };
        List<User> users = await _applicationDbContext.Users.Where(u => u.Email == registrationModel.Email).ToListAsync();
        if (users.Count != 0)
            return new UserManagerResponse { IsSuccess = false, Message = "Email exist" };
        IdentityRole role = await _roleManager.FindByNameAsync(registrationModel.Role.ToUpper());
        if (role is null)
            return new UserManagerResponse { IsSuccess = false, Message = "Role is not valid" };
        User validateUser = new () {
            PhoneNumber = registrationModel.Phone,
            UserName = registrationModel.UserName,
            Email = registrationModel.Email,
            Address = registrationModel?.Address,
            Photo = registrationModel.Photo,
            IsSelfEmployed = registrationModel.IsSelfEmployed
        };
        IdentityResult result = await _userManager.CreateAsync(validateUser, registrationModel.Password);
        if (!result.Succeeded)
            return new UserManagerResponse() { IsSuccess = false, Message = "Error registration" };
        await _userManager.AddToRoleAsync(validateUser, role.Name);
        return new UserManagerResponse() { IsSuccess = true, Message = await GetToken(validateUser) };
    }
    public async Task<UserManagerResponse> ForgetPassword(string email) {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
        string token = await _userManager.GeneratePasswordResetTokenAsync(user);
        byte[] encodedToken = Encoding.UTF8.GetBytes(token);
        string validToken = WebEncoders.Base64UrlEncode(encodedToken);
        string url = $"{_config["AuthSettings:Issuer"]}/Reset/{email}/{validToken}";
        bool isMailSuccess = await _mailService.SendLetter(email, "Восстановление пароля | Beauty", $"<h1>Восстановление пароля</h1><h3>Перейдите по <a href=\"{url}\">ссылке</a></h3>");
        return isMailSuccess ? new UserManagerResponse() { IsSuccess = true, Message = "Success" } : new UserManagerResponse() { IsSuccess = false, Message = "Error sending letter" };
    }
    public async Task<UserManagerResponse> ResetPassword(ResetPasswordVm resetPasswordVm) {
        var user = await _userManager.FindByEmailAsync(resetPasswordVm.Email);
        if (user is null)
            return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
        if (resetPasswordVm.Password != resetPasswordVm.ConfirmPassword)
            return new UserManagerResponse() { IsSuccess = false, Message = "" };
        byte[] decodedToken = WebEncoders.Base64UrlDecode(resetPasswordVm.Token);
        string normalToken = Encoding.UTF8.GetString(decodedToken);
        IdentityResult result = await _userManager.ResetPasswordAsync(user, normalToken, resetPasswordVm.Password);
        return result.Succeeded ? new UserManagerResponse() { IsSuccess = true, Message = "Password changed" } : new UserManagerResponse() { IsSuccess = false, Message = "Error reset" };
    }
}