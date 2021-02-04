using Asyn_Inn.Models.API;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces
{
  public interface IUserService
  {
    public Task<UserDTO> Register(RegisterUser data, ModelStateDictionary modelState);
    public Task<UserDTO> Authenticate(string username, string password);
  }
}
