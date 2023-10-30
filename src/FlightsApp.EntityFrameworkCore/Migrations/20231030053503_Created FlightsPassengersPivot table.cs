using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightsApp.Migrations
{
    /// <inheritdoc />
    public partial class CreatedFlightsPassengersPivottable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppFlightsPassengersPivot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    PassengerId = table.Column<int>(type: "int", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppFlightsPassengersPivot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppFlightsPassengersPivot_AppFlights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "AppFlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppFlightsPassengersPivot_AppPassengers_PassengerId",
                        column: x => x.PassengerId,
                        principalTable: "AppPassengers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AppFlightsPassengersPivot_FlightId",
                table: "AppFlightsPassengersPivot",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_AppFlightsPassengersPivot_PassengerId",
                table: "AppFlightsPassengersPivot",
                column: "PassengerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppFlightsPassengersPivot");
        }
    }
}
