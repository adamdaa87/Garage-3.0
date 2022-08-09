using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2._0.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingLot = table.Column<int>(type: "int", nullable: false),
                    RegNr = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    VehicleType = table.Column<int>(type: "int", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    NrOfWheels = table.Column<int>(type: "int", nullable: false),
                    TimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "Color", "Make", "Model", "NrOfWheels", "ParkingLot", "RegNr", "TimeOfArrival", "VehicleType" },
                values: new object[,]
                {
                    { 1, "Silver", "Volvo", "V70", 4, 1, "ABC123", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7040), 1 },
                    { 2, "Red", "Saab", "95", 4, 2, "DEF456", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7045), 1 },
                    { 3, "Green", "Ford", "Mustang", 4, 3, "GHI789", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7049), 1 },
                    { 4, "Black", "Harley-Davidson", "Pan America", 2, 4, "JKL891", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7054), 0 },
                    { 5, "Orange", "Scania", "XT", 6, 5, "MNO345", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7058), 2 },
                    { 6, "Yellow", "Scania", "zzz", 6, 6, "PQR912", new DateTime(2022, 7, 14, 11, 11, 25, 744, DateTimeKind.Local).AddTicks(7062), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
