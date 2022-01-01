namespace Beauty.API.Interfaces;
public interface IMailService {
    Task<bool> SendLetter(string email, string subject, string text);
}