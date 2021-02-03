using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models.API
{
  public class RoomDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public Layout RoomLayout { get; set; }
    public List<AmenitiesDTO> Amenities { get; set; }
  }
}
