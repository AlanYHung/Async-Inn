﻿using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces.Services
{
  public class IdentityUserService : IUserService
  {
    private readonly UserManager<ApplicationUser> userManager;
    private readonly JwtTokenService tokenService;

    public IdentityUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
    {
      userManager = manager;
      tokenService = jwtTokenService;
    }

    public async Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState)
    {
      //throw new NotImplementedException();

      var user = new ApplicationUser
      {
        UserName = data.Username,
        Email = data.Email,
        PhoneNumber = data.PhoneNumber
      };

      var result = await userManager.CreateAsync(user, data.Password);

      if (result.Succeeded)
      {
        // Because we have a "Good" user, let's add them to their proper role
        await userManager.AddToRolesAsync(user, data.Roles);
        return new UserDTO
        {
          Id = user.Id,
          Username = user.UserName,
        };
      }

      // Put errors into modelState
      // Ternary:   var foo = conditionIsTrue ? goodthing : bad;
      foreach (var error in result.Errors)
      {
        var errorKey =
          error.Code.Contains("Password") ? nameof(data.Password) :
          error.Code.Contains("Email") ? nameof(data.Email) :
          error.Code.Contains("UserName") ? nameof(data.Username) :
          "";

        modelState.AddModelError(errorKey, error.Description);
      }

      return null;
    }

    public async Task<UserDTO> Authenticate(string username, string password)
    {
      var user = await userManager.FindByNameAsync(username);

      if (await userManager.CheckPasswordAsync(user, password))
      {
        return new UserDTO
        {
          Id = user.Id,
          Username = user.UserName,
          Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
        };
      }

      return null;
    }

    // Use a "claim" to get a user
    public async Task<UserDTO> GetUser(ClaimsPrincipal principal)
    {
      var user = await userManager.GetUserAsync(principal);
      return new UserDTO
      {
        Id = user.Id,
        Username = user.UserName,
        Token = await tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
      };
    }
  }// end of class
}// end of namespace
