using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NumberController : ControllerBase
{
    private List<int> numbers = new List<int> { 2, 3, 5, 7, 11, 13 };

    [HttpGet("number")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Roles = "number", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public int getNumber()
    {
        var random = new Random();
        return numbers[random.Next(numbers.Count)];
    }
}