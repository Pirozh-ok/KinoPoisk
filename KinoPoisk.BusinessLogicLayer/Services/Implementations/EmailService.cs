using KinoPoisk.DomainLayer.Intarfaces.Services;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class EmailService : IEmailService {
        private readonly IConfiguration _configuration; 

        public EmailService(IConfiguration configuration) {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message) {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_configuration["SendEmail:FromName"], _configuration["SendEmail:AdminEmail"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = message
            };

            using (var client = new SmtpClient()) {
                await client.ConnectAsync(_configuration["SendEmail:SmtpHost"], int.Parse(_configuration["SendEmail:SmtpPort"]), false);
                await client.AuthenticateAsync(_configuration["SendEmail:AdminEmail"], _configuration["SendEmail:AdminPassword"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

    }
}
