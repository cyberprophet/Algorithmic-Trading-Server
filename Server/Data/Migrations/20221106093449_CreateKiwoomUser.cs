using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateKiwoomUser : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KiwoomUser",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumberOfAccounts = table.Column<int>(type: "int", nullable: false),
                    IsNotMock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KiwoomUser", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KiwoomUser_Id",
                table: "KiwoomUser",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KiwoomUser");
        }
    }
}