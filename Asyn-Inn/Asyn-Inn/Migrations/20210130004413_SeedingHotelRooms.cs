using Microsoft.EntityFrameworkCore.Migrations;

namespace Asyn_Inn.Migrations
{
    public partial class SeedingHotelRooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "PetFriendly", "Rate", "RoomId" },
                values: new object[] { 2, 777, false, 1139.99m, 3 });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelId", "RoomNumber", "PetFriendly", "Rate", "RoomId" },
                values: new object[] { 3, 1, true, 1.99m, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 2, 777 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelId", "RoomNumber" },
                keyValues: new object[] { 3, 1 });
        }
    }
}
