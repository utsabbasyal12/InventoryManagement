using Microsoft.Extensions.Configuration;
using MimeKit;
using MailKit.Net.Smtp;

namespace Shared.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmail(EmailDto request, List<string> recipents)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailSettings")["EmailUsername"]));
            foreach (var recipent in recipents)
            {
                email.To.Add(MailboxAddress.Parse(recipent));
            }
            //email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = request.Body };

            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailSettings")["EmailHost"], 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailSettings")["EmailUsername"], _configuration.GetSection("EmailSettings")["EmailPassword"]);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
