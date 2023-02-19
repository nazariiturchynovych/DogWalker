namespace DogWalker.Infrastructure.Services.EMailService;

using System.Net.Mail;

public interface IEmailService
{
    public Task SendAsync(MailMessage message);
}