# Lab11-13 ERD Framework / API

## Author: Alan Hung
## Contributors: David Dicken, Scott Falbo, Kjell Overholt, Jordan Kidwell

### Getting Started
* Open Visual Studio
* Clone [Async-Inn Git Repository](https://github.com/AlanYHung/Async-Inn)
* Click Run

### ERD Visual
![](./Asyn-Inn/Asyn-Inn/assets/AsyncInnERD.png)

### Explanation of Tables:
- **Hotel Table**: contains all of the hotel location information such as address and phone number.
- **Hotel Room Table**: contains the prices, room numbers and pet friendly attributes of the rooms.  Also acts as a joint entity table for the Hotel and Room Tables.
- **Room Table**: contains the characteristics of a bedroom that includes layout and name.
- **RoomAmenities Table**: contains the keys to the Room and Amenities Table and acts as a pure join table for the two.
- **Amenities Table**: contains all the amenities that a room can possibly have

### Explanation of Relationships:
-  *Hotel Table*:
   - 1:Many relationship w/ HotelRoom table in order to get the room data for the Hotel
- *HotelRoom Table(joint entity table)*:
  - Many:1 w/ Hotel table so it can match the rooms with their locations
  - Many:1 w/ Room table so it can pull more details about the room and vice versa
- *Room Table* 
  - 1:Many w/ hotelroom table in order to get price, room number, and pet friendly attributes
  - 1:Many w/ roomamenities table
  - Many:Many w/ amenities table so that it can get all the amenities the room comes with.  Where RoomAmenities is a pure join table that acts as the go between for the 2 tables.
  - Layout is an Enum describing the build structure of the room
- *RoomAmenities Table(pure join table)*:
  - Connects the room and amenities table together
  - Many:1 relationship with both room and amenities tables
- *Amenities Table*:
  - 1:Many relationship w/ the roomamenities table and stores all the possible amenities any of the rooms may have.

### Change Log
* 0.1.0 - 1/26/2021 3:15pm - Initial Repo and Project Setup
* 0.3.0 - 1/26/2021 3:50pm - Database & Models Added
* 0.6.0 - 1/26/2021 4:17pm - All Models Completed and Added
* 0.8.0 - 1/26/2021 5:05pm - All Models Seeded
* 1.0.0 - 1/26/2021 5:25pm - Controllers Added
* 1.0.5 - 1/27/2021 3:30pm - Dependence Injection Refactoring of Rooms
* 1.0.8 - 1/27/2021 4:22pm - Dependence Injection Refactoring of Hotel and Amenities

### Attribution
* [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/)
* [JSON to C# Class Constructor](https://json2csharp.com/)
