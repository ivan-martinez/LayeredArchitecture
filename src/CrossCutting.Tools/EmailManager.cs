using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace CrossCutting.Tools
{
    public class EmailManager
    {
        private readonly SmtpClient smtpClient;

        public EmailManager()
        {
            smtpClient = new SmtpClient("example.domain.com")
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("username", "password")
            };
        }
        public EmailManager(string host, string user, string pass)
        {
            smtpClient = new SmtpClient(host)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(user, pass)
            };
        }

        public void Send(string message, string subject)
        {
            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("info@domain.com")
            };
            mailMessage.To.Add("user1@domain.com");
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = Regex.IsMatch(message, @"<\s*a[^>]*>(.*?)<\s*/\s*a>");
            mailMessage.Subject = subject;

            smtpClient.Send(mailMessage);
        }
    }
}
