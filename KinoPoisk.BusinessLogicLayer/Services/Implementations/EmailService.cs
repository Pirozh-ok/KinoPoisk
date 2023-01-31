using KinoPoisk.DomainLayer.Intarfaces.Services;
using KinoPoisk.DomainLayer.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;

namespace KinoPoisk.BusinessLogicLayer.Services.Implementations {
    public class EmailService : IEmailService {
        private readonly IConfiguration _configuration;
        private readonly IOptions<SmtpSettings> _smtpSettings;

        public EmailService(
            IConfiguration configuration,
            IOptions<SmtpSettings> smtpSettings) {
            _configuration = configuration;
            _smtpSettings = smtpSettings;
        }

        public async Task SendEmailAsync(string email, string subject, string message) {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpSettings.Value.FromName, _smtpSettings.Value.AdminEmail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = message
            };

            using (var client = new SmtpClient()) {
                await client.ConnectAsync(_smtpSettings.Value.SmtpHost, _smtpSettings.Value.SmtpPort, false);
                await client.AuthenticateAsync(_smtpSettings.Value.AdminEmail, _smtpSettings.Value.AdminPassword);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

    }
}
