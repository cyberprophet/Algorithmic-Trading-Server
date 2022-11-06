using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateKiwoomMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KiwoomMessage",
                columns: table => new
                {
                    Lookup = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(37)", maxLength: 37, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Screen = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiwoomMessage", x => new { x.Key, x.Lookup });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KiwoomMessage");
        }
    }
}
