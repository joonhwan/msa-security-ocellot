using Microsoft.EntityFrameworkCore.Migrations;

namespace MireroTicket.Services.Discount.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    CouponId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.CouponId);
                });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "Amount", "UserId" },
                values: new object[] { "dcc03f5f-80d2-4e63-859d-29fc895d201f", 10, "e455a3df-7fa5-47e0-8435-179b300d531f" });

            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "CouponId", "Amount", "UserId" },
                values: new object[] { "7e7496d3-f7ac-4dd3-bff1-b6d36e4facd5", 20, "bbf594b0-3761-4a65-b04c-eec4836d9070" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coupons");
        }
    }
}
