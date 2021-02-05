using System.ComponentModel.DataAnnotations;

namespace Asyn_Inn.Models.API
{
  public class LoginData
  {
    [Required]
    public string Username { get; set; }
   
    [Required]
    public string Password { get; set; }
  }
}
