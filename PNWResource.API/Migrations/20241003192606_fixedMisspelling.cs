using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PNWResource.API.Migrations
{
    /// <inheritdoc />
    public partial class fixedMisspelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DaycareCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaycareCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaycareCenters_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStarts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeEnds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Libraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasChildrenSection = table.Column<bool>(type: "bit", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libraries_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schools_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Zoos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasChildrenArea = table.Column<bool>(type: "bit", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zoos_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DaycareCenterEvent",
                columns: table => new
                {
                    DaycareCenterId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaycareCenterEvent", x => new { x.DaycareCenterId, x.EventId });
                    table.ForeignKey(
                        name: "FK_DaycareCenterEvent_DaycareCenters_DaycareCenterId",
                        column: x => x.DaycareCenterId,
                        principalTable: "DaycareCenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DaycareCenterEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryEvent",
                columns: table => new
                {
                    LibraryId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryEvent", x => new { x.LibraryId, x.EventId });
                    table.ForeignKey(
                        name: "FK_LibraryEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryEvent_Libraries_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Libraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchoolEvent",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolEvent", x => new { x.SchoolId, x.EventId });
                    table.ForeignKey(
                        name: "FK_SchoolEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchoolEvent_Schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "Schools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZooEvent",
                columns: table => new
                {
                    ZooId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZooEvent", x => new { x.ZooId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ZooEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZooEvent_Zoos_ZooId",
                        column: x => x.ZooId,
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkEvent",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkEvent", x => new { x.ParkId, x.EventId });
                    table.ForeignKey(
                        name: "FK_ParkEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPlayground = table.Column<bool>(type: "bit", nullable: true),
                    HasPicnicArea = table.Column<bool>(type: "bit", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    PlaygroundId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parks_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Playgrounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasBathrooms = table.Column<bool>(type: "bit", nullable: true),
                    IsPetFriendly = table.Column<bool>(type: "bit", nullable: true),
                    DateConstructed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ParkId = table.Column<int>(type: "int", nullable: true),
                    ParkId1 = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playgrounds_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Playgrounds_Parks_ParkId1",
                        column: x => x.ParkId1,
                        principalTable: "Parks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaygroundEvent",
                columns: table => new
                {
                    PlaygroundId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaygroundEvent", x => new { x.PlaygroundId, x.EventId });
                    table.ForeignKey(
                        name: "FK_PlaygroundEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaygroundEvent_Playgrounds_PlaygroundId",
                        column: x => x.PlaygroundId,
                        principalTable: "Playgrounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_DaycareCenterEvent_EventId",
                table: "DaycareCenterEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_DaycareCenters_CityId",
                table: "DaycareCenters",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CityId",
                table: "Events",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_CityId",
                table: "Libraries",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryEvent_EventId",
                table: "LibraryEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkEvent_EventId",
                table: "ParkEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_CityId",
                table: "Parks",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Parks_PlaygroundId",
                table: "Parks",
                column: "PlaygroundId",
                unique: true,
                filter: "[PlaygroundId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlaygroundEvent_EventId",
                table: "PlaygroundEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_CityId",
                table: "Playgrounds",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Playgrounds_ParkId1",
                table: "Playgrounds",
                column: "ParkId1");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEvent_EventId",
                table: "SchoolEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Schools_CityId",
                table: "Schools",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ZooEvent_EventId",
                table: "ZooEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Zoos_CityId",
                table: "Zoos",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkEvent_Parks_ParkId",
                table: "ParkEvent",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Parks_Playgrounds_PlaygroundId",
                table: "Parks",
                column: "PlaygroundId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Parks_Cities_CityId",
                table: "Parks");

            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Cities_CityId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Parks_ParkId1",
                table: "Playgrounds");

            migrationBuilder.DropTable(
                name: "DaycareCenterEvent");

            migrationBuilder.DropTable(
                name: "LibraryEvent");

            migrationBuilder.DropTable(
                name: "ParkEvent");

            migrationBuilder.DropTable(
                name: "PlaygroundEvent");

            migrationBuilder.DropTable(
                name: "SchoolEvent");

            migrationBuilder.DropTable(
                name: "ZooEvent");

            migrationBuilder.DropTable(
                name: "DaycareCenters");

            migrationBuilder.DropTable(
                name: "Libraries");

            migrationBuilder.DropTable(
                name: "Schools");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Zoos");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Parks");

            migrationBuilder.DropTable(
                name: "Playgrounds");
        }
    }
}
