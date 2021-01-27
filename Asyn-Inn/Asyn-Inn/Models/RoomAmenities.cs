using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesId { get; set; }

        public int RoomId { get; set; }
    }
}
