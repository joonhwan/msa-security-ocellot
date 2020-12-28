using Microsoft.EntityFrameworkCore.Migrations;

namespace MireroTicket.Services.ShoppingBasket.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasketChangeEvents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    EventId = table.Column<string>(nullable: true),
                    InsertedAt = table.Column<string>(nullable: true),
                    BasetChangeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketChangeEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Baskets",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baskets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketLines",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    BasketId = table.Column<string>(nullable: false),
                    EventId = table.Column<string>(nullable: false),
                    TicketAmount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketLines_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketLines_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "ee272f8b-6096-4cb6-8625-bb4bb2d89e8b", "2021-06-28T14:41:52.6504580+09:00", "John Egbert Live" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "3448d5a4-0f72-4dd7-bf15-c14a46b26c00", "2021-09-28T14:41:52.6539740+09:00", "The State of Affairs: Michael Live!" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "b419a7ca-3321-4f38-be8e-4d7b6a529319", "2021-04-28T14:41:52.6539810+09:00", "Clash of the DJs" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "62787623-4c52-43fe-b0c9-b7044fb5929b", "2021-04-28T14:41:52.6539830+09:00", "Spanish guitar hits with Manuel" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "1babd057-e980-4cb3-9cd2-7fdd9e525668", "2021-10-28T14:41:52.6539920+09:00", "Techorama 2021" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { "adc42c09-08c1-4d2c-9f96-2d15bb1af299", "2021-08-28T14:41:52.6539930+09:00", "To the Moon and Back" });

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_BasketId",
                table: "BasketLines",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketLines_EventId",
                table: "BasketLines",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketChangeEvents");

            migrationBuilder.DropTable(
                name: "BasketLines");

            migrationBuilder.DropTable(
                name: "Baskets");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
