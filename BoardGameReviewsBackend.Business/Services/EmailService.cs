using System.Net;
using System.Net.Mail;

namespace BoardGameReviewsBackend.Business.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string toEmail, string subject, string htmlMessage)
    {
        var smtpHost = _configuration["Smtp:Host"];
        var smtpPort = int.Parse(_configuration["Smtp:Port"]);
        var smtpUser = _configuration["Smtp:Username"];
        var smtpPass = _configuration["Smtp:Password"];
        var fromEmail = _configuration["Smtp:From"];

        var client = new SmtpClient(smtpHost, smtpPort)
        {
            Credentials = new NetworkCredential(smtpUser, smtpPass),
            EnableSsl = true
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmail),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        await client.SendMailAsync(mailMessage);
    }
    
    public async Task SendWelcomeEmailAsync(string toEmail, string userName)
    {
        var templatePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "BoardGameReviewsBackend.Business", "EmailTemplates", "WelcomeEmail.html"));
        string emailBody = await File.ReadAllTextAsync(templatePath);

        emailBody = emailBody.Replace("{UserName}", userName);

        await SendEmailAsync(toEmail, "Welcome to Board Game Reviews!", emailBody);
    }
    
    public async Task SendConfirmationEmailAsync(string toEmail, string code)
    {
        var templatePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "BoardGameReviewsBackend.Business", "EmailTemplates", "ConfirmationEmail.html"));
        string emailBody = await File.ReadAllTextAsync(templatePath);

        emailBody = emailBody.Replace("{ConfirmationCode}", code);

        await SendEmailAsync(toEmail, "Your Confirmation Code is here", emailBody);
    }
    
}