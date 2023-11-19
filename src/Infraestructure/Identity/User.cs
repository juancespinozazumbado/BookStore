
using Microsoft.AspNetCore.Identity;

namespace Biblioteca.Infraestructure.Identity;

public class User : IdentityUser
{
    public string? UserImageUrl {get; private set;}
    
}