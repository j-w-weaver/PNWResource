using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PNWResource.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                name: "Library",
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
                    table.PrimaryKey("PK_Library", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Library_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "School",
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
                    table.PrimaryKey("PK_School", x => x.Id);
                    table.ForeignKey(
                        name: "FK_School_Cities_CityId",
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
                        name: "FK_LibraryEvent_Library_LibraryId",
                        column: x => x.LibraryId,
                        principalTable: "Library",
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
                        name: "FK_SchoolEvent_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
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
                name: "Park",
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
                    table.PrimaryKey("PK_Park", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Park_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
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
                    table.ForeignKey(
                        name: "FK_ParkEvent_Park_ParkId",
                        column: x => x.ParkId,
                        principalTable: "Park",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_Playgrounds_Park_ParkId1",
                        column: x => x.ParkId1,
                        principalTable: "Park",
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
                name: "IX_Library_CityId",
                table: "Library",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryEvent_EventId",
                table: "LibraryEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Park_CityId",
                table: "Park",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Park_PlaygroundId",
                table: "Park",
                column: "PlaygroundId",
                unique: true,
                filter: "[PlaygroundId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ParkEvent_EventId",
                table: "ParkEvent",
                column: "EventId");

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
                name: "IX_School_CityId",
                table: "School",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolEvent_EventId",
                table: "SchoolEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ZooEvent_EventId",
                table: "ZooEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Zoos_CityId",
                table: "Zoos",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Park_Playgrounds_PlaygroundId",
                table: "Park",
                column: "PlaygroundId",
                principalTable: "Playgrounds",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Park_Cities_CityId",
                table: "Park");

            migrationBuilder.DropForeignKey(
                name: "FK_Playgrounds_Cities_CityId",
                table: "Playgrounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Park_Playgrounds_PlaygroundId",
                table: "Park");

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
                name: "Library");

            migrationBuilder.DropTable(
                name: "School");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Zoos");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Playgrounds");

            migrationBuilder.DropTable(
                name: "Park");
        }
    }
}
