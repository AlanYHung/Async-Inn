using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Asyn_Inn.Models.API
{
  public class RegisterUser
  {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public List<string> Roles { get; set; }
  }
}
