using Asyn_Inn.Interfaces;
using Asyn_Inn.Models.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Asyn_Inn.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private IUserService userService;

    public UsersController(IUserService service)
    {
      userService = service;
    }

    // POST: api/Users/Register
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<ActionResult<UserDTO>> Register(RegisterUser data)
    {
      var user = await userService.Register(data, this.ModelState);

      if (ModelState.IsValid)
      {
        return user;
      }

      return BadRequest(new ValidationProblemDetails(ModelState));
    }

    // POST: api/Users/Login
    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<ActionResult<UserDTO>> Login(LoginData data)
    {
      var user = await userService.Authenticate(data.Username, data.Password);
      if (user != null)
      {
        return user;
      }
      return Unauthorized();
    }

    // Whoa! New annotation that will be able to Read the bearer token
    // and return a user based on the claim/principal within...
    [HttpGet("me")]
    public async Task<ActionResult<UserDTO>> Me()
    {
      // Following the [Authorize] phase, this.User will be ... you.
      // Put a breakpoint here and inspect to see what's passed to our getUser method
      return await userService.GetUser(this.User);
    }
  }
}
