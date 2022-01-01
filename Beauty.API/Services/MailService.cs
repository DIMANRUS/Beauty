namespace Beauty.API.Services {
    public class MailService : IMailService {
        private MailMessage _mail;
        private SmtpClient _smtp;
        public async Task<bool> SendLetter(string email, string subject, string text) {
            _mail = new MailMessage();
            _smtp = new SmtpClient("smtp.yandex.ru");
            _mail.From = new MailAddress("dimanrusdev33@yandex.ru");
            _mail.To.Add(email);
            _mail.Subject = subject;
            _mail.Body = text;
            _mail.IsBodyHtml = true;
            _smtp.Port = 587;
            _smtp.Credentials = new NetworkCredential("dimanrusdev33@yandex.ru", "kcidkvgvbeprgiyb");
            _smtp.EnableSsl = true;
            try {
                await _smtp.SendMailAsync(_mail);
                return true;
            } catch {
                return false;
            }
        }
    }
}