﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
