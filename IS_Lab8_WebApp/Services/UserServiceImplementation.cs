using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Entities;
using WebApplication1.Model;

namespace WebApplication1.Services;

public class UserServiceImplementation : IUserService
{
    private static List<User> users = new List<User>
    {
        new User
        {
            Id = 1, Username = "Andrzej", Password = "Andrzej",
            Roles = new List<Role>
            {
                new Role { Role_ = "admin" },
                new Role { Role_ = "user" }
            }
        },
        new User
        {
            Id = 2, Username = "Piotrek", Password = "Piotrek",
            Roles = new List<Role>
            {
                new Role { Role_ = "number" },
                new Role { Role_ = "user" }
            }
        },
        new User
        {
            Id = 3, Username = "Ania", Password = "Ania",
            Roles = new List<Role>
            {
                new Role { Role_ = "user" }
            }
        }
    };

    private IConfiguration configuration;
    public UserServiceImplementation(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public AuthenticationResponse Authenticate(AuthenticationRequest request)
    {
        User user = GetByUsername(request.Username);
        if (user == null || user.Password != request.Password)
        {
            return null;
        }

        string token = generateJwtToken(user);
        return new AuthenticationResponse(user, token);
    }

    public IEnumerable<User> GetUsers()
    {
        return users;
    }

    public User GetByUsername(string username)
    {
        return users.FirstOrDefault(x => x.Username == username);
    }

    public User GetById(int id)
    {
        return users.FirstOrDefault(x => x.Id == id);
    }

    /**
     * metoda generująca tokeny jwt dla danego użytkownika, pobiera klucz z appsettings.json
     *  następnie wypełnia treść tokena zapisując informacje o id użytkownika oraz jego rolach.
     * Na koniec generuje token i podpisuje go kluczem.
     */
    public string generateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:key"]);
        var claims = new List<Claim>();
        claims.Add(new Claim("id", user.Id.ToString()));
        foreach (var role in user.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Role_));
        }

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims.ToArray()),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =  
                new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature) 
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}