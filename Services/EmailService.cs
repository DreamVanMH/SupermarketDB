using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SupermarketDB.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var emailSettings = _configuration.GetSection("EmailSettings");

            using (var smtpClient = new SmtpClient(emailSettings["SmtpServer"]))
            {
                smtpClient.Port = int.Parse(emailSettings["SmtpPort"]);
                smtpClient.Credentials = new NetworkCredential(emailSettings["Username"], emailSettings["Password"]);
                smtpClient.EnableSsl = true;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailSettings["SenderEmail"], emailSettings["SenderName"]),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                try
                {
                    await smtpClient.SendMailAsync(mailMessage);
                    Console.WriteLine("✅ Email sent successfully to " + toEmail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Failed to send email: " + ex.Message);
                }
            }
        }
    }
}
