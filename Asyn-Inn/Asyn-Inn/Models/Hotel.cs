﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models
{
    public class Hotel
    {
        [Key]
        public int Id { get; set; }
 
        [ForeignKey("")]
        public int HotelRoom { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}
