using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models
{
    public class Amenities
    {
        [Key]
        public int RoomNumber { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
