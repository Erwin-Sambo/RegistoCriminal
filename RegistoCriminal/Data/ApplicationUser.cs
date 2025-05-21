using Microsoft.AspNetCore.Identity;

namespace RegistoCriminal.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string NomeCompleto { get; set; } = null!;
    }
}
