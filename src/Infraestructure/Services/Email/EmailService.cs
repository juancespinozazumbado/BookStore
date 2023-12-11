
using BookStore.Core.interfaces;

namespace  BookStore.Infraestructure.Services.Email;

public class EmailService : IEmailService
{
    public Task SendEmail(string from, string subject, string message)
    {
        throw new NotImplementedException();
    }
}