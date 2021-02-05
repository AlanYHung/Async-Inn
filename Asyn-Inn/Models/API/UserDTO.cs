using System.Collections.Generic;

namespace Asyn_Inn.Models.API
{
  public class UserDTO
  {
    public string Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
    public List<string> Roles { get; set; }
  }
}
