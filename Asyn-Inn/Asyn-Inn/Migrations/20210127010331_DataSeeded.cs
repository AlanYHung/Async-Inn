using Microsoft.EntityFrameworkCore.Migrations;

namespace Asyn_Inn.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelRoom",
                table: "Hotels");

            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomLayout = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Amenity",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Microwave" },
                    { 2, "50-inch 4K LED Television" },
                    { 3, "Swimming Pool" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "City", "Country", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Middle of Nowhere", "Does Not Exist", "Async Inn", "999-999-9999", "In Space", "1111 Nowhere Lane" },
                    { 2, "Outside of Nowhere", "Does Not Exist", "Async Shore", "777-777-7777", "In Galaxy", "2222 Nowhere Lane" },
                    { 3, "Out of Nowhere", "Big Bang", "Async Cliffs", "111-111-1111", "In Universe", "3333 Nowhere Lane" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name", "RoomLayout" },
                values: new object[,]
                {
                    { 1, "Singularity X", 0 },
                    { 2, "Black Hole Y", 1 },
                    { 3, "Event Horizon Z", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "HotelRoom",
                table: "Hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
