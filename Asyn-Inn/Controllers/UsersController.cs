using Asyn_Inn.Interfaces;
using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Controllers
{
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
  }
}
