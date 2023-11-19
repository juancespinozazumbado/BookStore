using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Biblioteca.Core.interfaces;

public interface IEmailService
{
    public Task SendEmail(string from, string subject, string message);
}