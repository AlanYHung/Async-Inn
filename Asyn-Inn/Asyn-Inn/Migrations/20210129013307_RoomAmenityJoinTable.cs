using Microsoft.EntityFrameworkCore.Migrations;

namespace Asyn_Inn.Migrations
{
    public partial class RoomAmenityJoinTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoomAmenity",
                columns: table => new
                {
                    AmenitiesId = table.Column<int>(nullable: false),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenity", x => new { x.RoomId, x.AmenitiesId });
                    table.ForeignKey(
                        name: "FK_RoomAmenity_Amenity_AmenitiesId",
                        column: x => x.AmenitiesId,
                        principalTable: "Amenity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenity_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenity_AmenitiesId",
                table: "RoomAmenity",
                column: "AmenitiesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAmenity");
        }
    }
}
