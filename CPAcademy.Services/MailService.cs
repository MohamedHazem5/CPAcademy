using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CPAcademy.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailsettings;

        public MailService(IOptions<MailSettings> mailsettings)
        {
            _mailsettings = mailsettings.Value;
        }

        public async Task SendEmailAsync(string mailTo, string subject, string body)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailsettings.Email),
                Subject = subject,
            };

            email.To.Add(MailboxAddress.Parse(mailTo));

            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailsettings.DisplayName, _mailsettings.Email));

            using var smtp = new SmtpClient();

            smtp.Connect(_mailsettings.Host, _mailsettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailsettings.Email, _mailsettings.Password);
            await smtp.SendAsync(email);

            smtp.Disconnect(true);
        }
    }
}