using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PNWResource.API.Migrations
{
    /// <inheritdoc />
    public partial class initSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { 1, "Portland", "OR" },
                    { 2, "Salem", "OR" },
                    { 3, "Vancouver", "WA" }
                });

            migrationBuilder.InsertData(
                table: "Playgrounds",
                columns: new[] { "Id", "Address", "CityId", "DateConstructed", "DateUpdated", "HasBathrooms", "IsPetFriendly", "Name", "ParkId", "ParkId1", "State" },
                values: new object[,]
                {
                    { 1, "", 1, null, null, null, null, "Adventure Cove", null, null, "" },
                    { 2, "", 1, null, null, null, null, "Sunny Meadows Park", null, null, "" },
                    { 3, "", 2, null, null, null, null, "Jungle Jumper Playground", null, null, "" },
                    { 4, "", 2, null, null, null, null, "Splash & Dash Park", null, null, "" },
                    { 5, "", 3, null, null, null, null, "Little Explorers Park", null, null, "" },
                    { 6, "", 3, null, null, null, null, "Rainbow Slide Haven", null, null, "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Playgrounds",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
