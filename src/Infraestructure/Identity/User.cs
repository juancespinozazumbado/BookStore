
using Microsoft.AspNetCore.Identity;

namespace BookStore.Infraestructure.Identity;

public class User : IdentityUser
{
    public string? UserImageUrl {get; private set;}
    
}