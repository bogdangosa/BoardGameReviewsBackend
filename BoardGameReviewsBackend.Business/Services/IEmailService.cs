namespace BoardGameReviewsBackend.Business.Services;

public interface IEmailService
{
    public Task SendEmailAsync(string toEmail, string subject, string htmlMessage);
    public Task SendWelcomeEmailAsync(string toEmail, string userName);
    public Task SendConfirmationEmailAsync(string toEmail, string code);
}