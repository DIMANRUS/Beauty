using Beauty.API.Interfaces;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Beauty.API.Services {
    public class MailService : IMailService {
        MailMessage mail;
        SmtpClient smtp;
        public async Task<bool> SendLetter(string email, string subject, string text) {
            mail = new MailMessage();
            smtp = new SmtpClient("smtp.yandex.ru");
            mail.From = new MailAddress("dimanrusdev33@yandex.ru");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = text;
            mail.IsBodyHtml = true;
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("dimanrusdev33@yandex.ru", "kcidkvgvbeprgiyb");
            smtp.EnableSsl = true;
            try {
                await smtp.SendMailAsync(mail);
                return true;
            } catch {
                return false;
            }
        }
    }
}