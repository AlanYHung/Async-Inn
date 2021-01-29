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
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Rate { get; set; }

    public bool PetFriendly { get; set; }

    // Navigation Properties
    // These specify the link between these tables
    public Hotel Hotel { get; set; }
    public Room Room { get; set; }
  }
}
