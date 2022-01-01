namespace Beauty.API.Interfaces;
public interface IUserService {
    Task<UserManagerResponse> Register(RegistrationModelRequest registrationModel);
    Task<UserManagerResponse> Login(LoginModelRequest loginModel);
    Task<UserManagerResponse> ForgetPassword(string email);
    Task<UserManagerResponse> ResetPassword(ResetPasswordVm resetPasswordVm);
}