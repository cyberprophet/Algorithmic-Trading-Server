using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class AlterFileVersionInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ticks",
                table: "FileVersionInfo",
                newName: "Publish");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Publish",
                table: "FileVersionInfo",
                newName: "Ticks");
        }
    }
}
