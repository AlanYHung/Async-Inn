using Microsoft.EntityFrameworkCore.Migrations;

namespace Asyn_Inn.Migrations
{
    public partial class seededRoomAmenities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "RoomAmenity",
                columns: new[] { "RoomId", "AmenitiesId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RoomAmenity",
                keyColumns: new[] { "RoomId", "AmenitiesId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
