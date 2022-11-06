using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShareInvest.Server.Data.Migrations
{
    public partial class CreateOPTKWFID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OPTKWFID",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    State = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ConstructionSupervision = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    InvestmentCaution = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ListingDate = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Current = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Price = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompareToPreviousDay = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompareToPreviousSign = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Rate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TransactionAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ContractAmount = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FasteningStrength = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CompareToPreviousVolume = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Offer = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Bid = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OfferAlpha = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OfferBeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OfferGamma = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OfferDelta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OfferEpsilon = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BidAlpha = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BidBeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BidGamma = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BidDelta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BidEpsilon = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    UpperLimit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LowerLimit = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    StartingPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    HighPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    LowPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ClosingPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FasteningTime = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ExpectedPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    EstimatedContractVolume = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Capital = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    FaceValue = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    MarketCap = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfListedStocks = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    QuoteTime = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Date = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PreferredOfferRemaining = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    PreferredBidRemaining = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfPreferentialOffer = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfPreferentialBid = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalOfferRemaining = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TotalBidRemaining = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfTotalOffer = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    NumberOfTotalBid = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Parity = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Gearing = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    BreakEven = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    CapitalSupport = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ELWEventPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ConversionRate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ELWDueDate = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    OpenInterest = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ComparePreviousOutstanding = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    TheoreticalPrice = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    ImpliedVolatility = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Delta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Gamma = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Theta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Vega = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Rho = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OPTKWFID", x => x.Code);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OPTKWFID");
        }
    }
}
