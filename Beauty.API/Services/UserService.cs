using System;
using System.Threading.Tasks;
using Beauty.Shared.Requests;
using Beauty.API.Interfaces;
using Microsoft.AspNetCore.Identity;
using Beauty.EFDataAccessLibrary.Models;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.EntityFrameworkCore;
using Beauty.EFDataAccessLibrary.Contexts;
using System.Linq;
using Microsoft.AspNetCore.WebUtilities;
using Beauty.API.ViewModels;
using Beauty.API.Responses;

namespace Beauty.API.Services {
    public class UserService : IUserService {
        private UserManager<User> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _applicationDbContext;
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
            var role = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(user.Id));
            var claims = new[] {
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, user.Id),
                            new Claim(ClaimTypes.Role, role.First()),
                            new Claim(ClaimTypes.Name, user.UserName)
                        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["AuthSettings:Key"]));

            var token = new JwtSecurityToken(
                issuer: _config["AuthSettings:Issuer"],
                audience: _config["AuthSettings:Audience"],
                expires: DateTime.Now.AddDays(50),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<UserManagerResponse> Login(LoginModelRequest loginModel) {
            if (loginModel is not null) {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user is not null) {
                    var resultPassword = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                    if (resultPassword) {
                        return new UserManagerResponse { IsSuccess = true, Message = await GetToken(user) };
                    }
                    return new UserManagerResponse() { IsSuccess = false, Message = "Password invalid" };
                }
                return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
            }
            return new UserManagerResponse() { IsSuccess = false, Message = "Model is null" };
        }
        public async Task<UserManagerResponse> Register(RegistrationModelRequest registrationModel) {
            if (registrationModel is not null) {
                var users = await _applicationDbContext.Users.Where(u => u.Email == registrationModel.Email).ToListAsync();
                if (users.Count == 0) {
                    var role = await _roleManager.FindByNameAsync(registrationModel.Role.ToUpper());
                    if (role is not null) {
                        var validateUser = new User() {
                            PhoneNumber = registrationModel.Phone,
                            UserName = registrationModel.UserName,
                            Email = registrationModel.Email,
                            Address = registrationModel?.Address,
                            Photo = registrationModel.Photo,
                            IsSelfEmployed = registrationModel.IsSelfEmployed
                        };
                        var result = await _userManager.CreateAsync(validateUser, registrationModel.Password);
                        if (result.Succeeded) {
                            await _userManager.AddToRoleAsync(validateUser, role.Name);
                            return new UserManagerResponse() { IsSuccess = true, Message = await GetToken(validateUser) };
                        }
                        return new UserManagerResponse() { IsSuccess = false, Message = "Error registration" };
                    }
                    return new UserManagerResponse() { IsSuccess = false, Message = "Role is not valid" };
                }
                return new UserManagerResponse() { IsSuccess = false, Message = "Email exist" };
            }
            return new UserManagerResponse() { IsSuccess = false, Message = "Model is null" };
        }
        public async Task<UserManagerResponse> ForgetPassword(string email) {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is not null) {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var encodedToken = Encoding.UTF8.GetBytes(token);
                var validToken = WebEncoders.Base64UrlEncode(encodedToken);
                string url = $"{_config["AuthSettings:Issuer"]}/Reset/{email}/{validToken}";
                var isMailSuccess = await _mailService.SendLetter(email, "Восстановление пароля | Beauty", $"<h1>Восстановление пароля</h1><h3>Перейдите по <a href=\"{url}\">ссылке</a></h3>");
                if (isMailSuccess)
                    return new UserManagerResponse() { IsSuccess = true, Message = "Success" };
                return new UserManagerResponse() { IsSuccess = false, Message = "Error sending letter" };
            }
            return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
        }
        public async Task<UserManagerResponse> ResetPassword(ResetPasswordVM resetPasswordVM) {
            var user = await _userManager.FindByEmailAsync(resetPasswordVM.Email);
            if (user is not null) {
                if (resetPasswordVM.Password == resetPasswordVM.ConfirmPassword) {
                    var decodedToken = WebEncoders.Base64UrlDecode(resetPasswordVM.Token);
                    string normalToken = Encoding.UTF8.GetString(decodedToken);
                    var result = await _userManager.ResetPasswordAsync(user, normalToken, resetPasswordVM.Password);
                    if (result.Succeeded)
                        return new UserManagerResponse() { IsSuccess = true, Message = "Password changed" };
                    return new UserManagerResponse() { IsSuccess = false, Message = "Error reset" };
                }
                return new UserManagerResponse() { IsSuccess = false, Message = "" };
            }
            return new UserManagerResponse() { IsSuccess = false, Message = "User not found" };
        }
    }
}