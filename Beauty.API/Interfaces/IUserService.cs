using System.Threading.Tasks;
using Beauty.Shared.Response;
using Beauty.Shared.ViewModels;
using Beauty.API.ViewModels;

namespace Beauty.API.Interfaces {
    public interface IUserService {
        Task<UserManagerResponse> Register(RegistrationViewModel registrationViewModel);
        Task<UserManagerResponse> Login(LoginViewModel loginViewModel);
        Task<UserManagerResponse> ForgetPassword(string email);
        Task<UserManagerResponse> ResetPassword(ResetPasswordVM resetPasswordVM);
    }
}
