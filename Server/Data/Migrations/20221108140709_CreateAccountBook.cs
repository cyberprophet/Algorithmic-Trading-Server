﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateAccountBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_KiwoomUser",
                table: "KiwoomUser");

            migrationBuilder.DropIndex(
                name: "IX_KiwoomUser_Id",
                table: "KiwoomUser");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "KiwoomUser",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccNo",
                table: "KiwoomUser",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KiwoomUser",
                table: "KiwoomUser",
                columns: new[] { "Key", "AccNo" });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Lookup = table.Column<long>(type: "bigint", nullable: false),
                    AccNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Deposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PresumeDeposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Balance = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Asset = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalPurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PresumeAsset = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    MortgageLoan = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SameDayInvestment = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CurrentMonthInvestment = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    AccumulatedInvestment = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SameDayProfitAndLoss = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CurrentMonthProfitAndLoss = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    AccumulatedProfitAndLoss = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProfitAndLossPercentageForTheDay = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ProfitAndLossPercentageForTheCurrentMonth = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CumulativeProfitPercentage = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfPrints = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => new { x.AccNo, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "Balance",
                columns: table => new
                {
                    Lookup = table.Column<long>(type: "bigint", nullable: false),
                    AccNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Average = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Current = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Evaluation = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Loan = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Purchase = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PaymentBalance = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PreviousPurchaseQuantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PreviousSalesQuantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PurchaseQuantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    SalesQuantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balance", x => new { x.AccNo, x.Date, x.Code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Balance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KiwoomUser",
                table: "KiwoomUser");

            migrationBuilder.DropColumn(
                name: "AccNo",
                table: "KiwoomUser");

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "KiwoomUser",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KiwoomUser",
                table: "KiwoomUser",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_KiwoomUser_Id",
                table: "KiwoomUser",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");
        }
    }
}
