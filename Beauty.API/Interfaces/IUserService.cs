using System.Threading.Tasks;
using Beauty.API.Responses;
using Beauty.Shared.Requests;
using Beauty.API.ViewModels;

namespace Beauty.API.Interfaces {
    public interface IUserService {
        Task<UserManagerResponse> Register(RegistrationModelRequest registrationModel);
        Task<UserManagerResponse> Login(LoginModelRequest loginModel);
        Task<UserManagerResponse> ForgetPassword(string email);
        Task<UserManagerResponse> ResetPassword(ResetPasswordVM resetPasswordVM);
    }
}
