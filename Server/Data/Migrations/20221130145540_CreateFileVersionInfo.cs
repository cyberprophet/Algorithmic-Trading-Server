using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateFileVersionInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileVersionInfo",
                columns: table => new
                {
                    App = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    FileBuildPart = table.Column<int>(type: "int", nullable: false),
                    FileDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    FileMajorPart = table.Column<int>(type: "int", nullable: false),
                    FileMinorPart = table.Column<int>(type: "int", nullable: false),
                    FilePrivatePart = table.Column<int>(type: "int", nullable: false),
                    FileVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    Ticks = table.Column<long>(type: "bigint", nullable: false),
                    InternalName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    OriginalFileName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    PrivateBuild = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductBuildPart = table.Column<int>(type: "int", nullable: false),
                    ProductMajorPart = table.Column<int>(type: "int", nullable: false),
                    ProductMinorPart = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    ProductPrivatePart = table.Column<int>(type: "int", nullable: false),
                    ProductVersion = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileVersionInfo", x => new { x.App, x.Path, x.FileName });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileVersionInfo");
        }
    }
}
