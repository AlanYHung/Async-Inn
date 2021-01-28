using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models
{
  public class HotelRoom
  {
    public int HotelId { get; set; }

    [Required]
    public int RoomNumber { get; set; }

    public int RoomId { get; set; }

    [Required]
    public decimal Rate { get; set; }

    public byte PetFriendly { get; set; }
  }
}
