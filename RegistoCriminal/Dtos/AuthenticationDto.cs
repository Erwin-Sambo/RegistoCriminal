namespace RegistoCriminal.Dtos
{
    public class AuthenticationDto
    {
    }

    public class LoginDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class RegisterDto
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string NomeCompleto { get; set; } = null!;
    }
}
