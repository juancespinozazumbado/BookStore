namespace BookStore.Core.interfaces;

public interface IEmailService
{
    public Task SendEmail(string from, string subject, string message);
}