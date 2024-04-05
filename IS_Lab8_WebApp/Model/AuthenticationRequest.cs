using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model;

public class AuthenticationRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}