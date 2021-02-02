using Asyn_Inn.Data;
using Asyn_Inn.Models;
using Asyn_Inn.Models.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asyn_Inn.Interfaces.Services
{
  public class HotelRepository : IHotel
  {
    private AsyncInnDbContext _context;

    public HotelRepository(AsyncInnDbContext context)
    {
      _context = context;
    }

    public async Task<Hotel> Create(HotelDTO hotel)
    {
      Hotel newHotel = new Hotel()
      {
        Id = hotel.Id,
        Name = hotel.Name,
        StreetAddress = hotel.StreetAddress,
        City = hotel.City,
        State = hotel.State,
        Phone = hotel.Phone
      };

      _context.Entry(newHotel).State = EntityState.Added;
      await _context.SaveChangesAsync();
      return newHotel;
    }

    public async Task DeleteHotel(int id)
    {
      HotelDTO hotel = await GetHotel(id);
      _context.Entry(hotel).State = EntityState.Deleted;
      await _context.SaveChangesAsync();
    }

    public async Task<HotelDTO> GetHotel(int id)
    {
      HotelDTO hotel = await _context.Hotels
                                     .Where(h => h.Id == id)
                                     .Select(h => new HotelDTO()
                                     {
                                       Id = h.Id,
                                       Name = h.Name,
                                       StreetAddress = h.StreetAddress,
                                       City = h.City,
                                       State = h.State,
                                       Phone = h.Phone,
                                       Rooms = h.HotelRooms
                                                .Select(hr => new HotelRoomDTO()
                                                {
                                                  HotelId = hr.HotelId,
                                                  RoomNumber = hr.RoomNumber,
                                                  Rate = hr.Rate,
                                                  PetFriendly = hr.PetFriendly,
                                                  RoomId = hr.RoomId,
                                                  Room = hr.Room.HotelRooms
                                                                .Select(r => new RoomDTO()
                                                                {
                                                                  Id = r.Room.Id,
                                                                  Name = r.Room.Name,
                                                                  RoomLayout = r.Room.RoomLayout,
                                                                  //Amenities = r.Room.RoomAmenities
                                                                  //                  .Select(ra => new AmenitiesDTO()
                                                                  //                  {
                                                                  //                    Id = ra.Amenity.Id,
                                                                  //                    Name = ra.Amenity.Name
                                                                  //                  })
                                                                  //                  .ToList()
                                                                })
                                                                .FirstOrDefault()
                                                })
                                                .ToList()
                                     })
                                     .FirstOrDefaultAsync();

      return hotel;
    }

    public async Task<List<HotelDTO>> GetHotels()
    {
      //var rooms = await _context.Amenity
      //                              .Where()
      //                              .ToListAsync();
      //List<AmenitiesDTO> amenityList = new List<AmenitiesDTO>();

      //foreach (var amenity in amenities)
      //{
      //  var newAmenity = await _context.Amenity
      //  amenityList = newAmenity;
      //}
      var hotels = await _context.Hotels
                                 .Select(h => new HotelDTO()
                                 {
                                   Id = h.Id,
                                   Name = h.Name,
                                   StreetAddress = h.StreetAddress,
                                   City = h.City,
                                   State = h.State,
                                   Phone = h.Phone,
                                   Rooms = h.HotelRooms
                                            .Select(hr => new HotelRoomDTO()
                                            {
                                              HotelId = hr.HotelId,
                                              RoomNumber = hr.RoomNumber,
                                              Rate = hr.Rate,
                                              PetFriendly = hr.PetFriendly,
                                              RoomId = hr.RoomId,
                                              Room = hr.Room.HotelRooms
                                                            .Select(r => new RoomDTO()
                                                            {
                                                              Id = r.Room.Id,
                                                              Name = r.Room.Name,
                                                              RoomLayout = r.Room.RoomLayout,
                                                              Amenities = amenityList
                                                              //Amenities = r.Room.RoomAmenities
                                                              //                  .Select(ra => new AmenitiesDTO()
                                                              //                  {
                                                              //                    Id = ra.Amenity.Id,
                                                              //                    Name = ra.Amenity.Name
                                                              //                  })
                                                              //                  .ToList()
                                                            })
                                                            .FirstOrDefault()
                                            })
                                            .ToList()
                                  })
                                  .ToListAsync();


      return hotels;
    }

    public async Task<Hotel> UpdateHotel(int id, HotelDTO hotel)
    {
      Hotel newHotel = new Hotel()
      {
        Id = hotel.Id,
        Name = hotel.Name,
        StreetAddress = hotel.StreetAddress,
        City = hotel.City,
        State = hotel.State,
        Phone = hotel.Phone
      };

      _context.Entry(newHotel).State = EntityState.Modified;
      await _context.SaveChangesAsync();
      return newHotel;
    }
  }
}
