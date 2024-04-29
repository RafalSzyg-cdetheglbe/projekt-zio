using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseAudits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAudits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Login = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserAuditId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_BaseAudits_UserAuditId",
                        column: x => x.UserAuditId,
                        principalTable: "BaseAudits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MeteoStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    CreatorId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteoStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeteoStations_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeteoData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ValueType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuditDataId = table.Column<int>(type: "int", nullable: true),
                    DataType = table.Column<int>(type: "int", nullable: false),
                    MeteoStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteoData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeteoData_BaseAudits_AuditDataId",
                        column: x => x.AuditDataId,
                        principalTable: "BaseAudits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MeteoData_MeteoStations_MeteoStationId",
                        column: x => x.MeteoStationId,
                        principalTable: "MeteoStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeteoData_AuditDataId",
                table: "MeteoData",
                column: "AuditDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteoData_MeteoStationId",
                table: "MeteoData",
                column: "MeteoStationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteoStations_CreatorId",
                table: "MeteoStations",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAuditId",
                table: "Users",
                column: "UserAuditId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeteoData");

            migrationBuilder.DropTable(
                name: "MeteoStations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BaseAudits");
        }
    }
}
