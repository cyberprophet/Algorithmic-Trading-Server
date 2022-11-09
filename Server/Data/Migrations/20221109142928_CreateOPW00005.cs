using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateOPW00005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountOPW00005",
                columns: table => new
                {
                    Lookup = table.Column<long>(type: "bigint", nullable: false),
                    AccNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Deposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PreDeposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PresumeDeposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    WithDrawableAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    UncollectedSecurity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Loan = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LoanForRights = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OrderableCash = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CashReceivables = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    UnpaidInterestOnCredit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OtherLoans = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OutstandingLoan = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CashOnDeposit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DepositSubstitute = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalStockPurchases = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EvaluationAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalProfitAndLoss = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    GrossProfitAndLossRatio = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OneFifthAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OneThirdAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TwoFifthsAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    HalfAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TwoThirdsAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FullAvailablePurchaseAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalCreditLoans = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreditLoan = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CreditSecurityRatio = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    DepositedMortgageAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    MortgageSoldAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfViews = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountOPW00005", x => new { x.AccNo, x.Date });
                });

            migrationBuilder.CreateTable(
                name: "BalanceOPW00005",
                columns: table => new
                {
                    Lookup = table.Column<long>(type: "bigint", nullable: false),
                    AccNo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    Date = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Credit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LoanDate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PaymentBalance = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Quantity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Current = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Average = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Purchase = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Evaluation = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Amount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BalanceOPW00005", x => new { x.AccNo, x.Date, x.Code });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountOPW00005");

            migrationBuilder.DropTable(
                name: "BalanceOPW00005");
        }
    }
}
