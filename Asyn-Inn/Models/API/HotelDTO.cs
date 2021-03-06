﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Models.API
{
  public class HotelDTO
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Phone { get; set; }
    public List<HotelRoomDTO> Rooms { get; set; }
  }
}
