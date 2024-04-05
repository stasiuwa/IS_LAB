using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost("/authenticate")]
    public IActionResult Authenticate(AuthenticationRequest request)
    {
        var response = userService.Authenticate(request);
        if (response == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        return Ok(response);
    }
}