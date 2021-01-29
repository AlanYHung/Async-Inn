using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models
{
  public class Room
  {
    public int Id { get; set; }

    [Required]
    public Layout RoomLayout { get; set; }

    public string Name { get; set; }

    public List<RoomAmenities> RoomAmenities { get; set; }

    public List<HotelRoom> HotelRooms { get; set; }
  }

  public enum Layout
  {
    Studio,
    OneBedroom,
    TwoBedroom
  }
}
