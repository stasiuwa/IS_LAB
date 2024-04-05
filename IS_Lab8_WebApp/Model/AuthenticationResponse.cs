namespace WebApplication1.Model;

public class AuthenticationResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }

    public AuthenticationResponse(Entities.User user, string token)
    {
        Id = user.Id;
        Username = user.Username;
        Token = token;
    }
}