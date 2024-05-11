using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class PoprawaInstancji : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "MeteoStations",
                newName: "AuditDataId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteoStations_AuditDataId",
                table: "MeteoStations",
                column: "AuditDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_MeteoStations_BaseAudits_AuditDataId",
                table: "MeteoStations",
                column: "AuditDataId",
                principalTable: "BaseAudits",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeteoStations_BaseAudits_AuditDataId",
                table: "MeteoStations");

            migrationBuilder.DropIndex(
                name: "IX_MeteoStations_AuditDataId",
                table: "MeteoStations");

            migrationBuilder.RenameColumn(
                name: "AuditDataId",
                table: "MeteoStations",
                newName: "UserId");
        }
    }
}
