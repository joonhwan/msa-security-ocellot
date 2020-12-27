using Microsoft.EntityFrameworkCore.Migrations;

namespace MireroTicket.Services.EventCatalog.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Artist = table.Column<string>(nullable: true),
                    Date = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "b0788d2f-8003-43c1-92a4-edc76a7c5dde", "Concerts" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "6313179f-7837-473a-a4d5-a5571b43e6a6", "Musicals" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "bf3f3002-7e53-441e-8b76-f6280be284aa", "Plays" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { "fe98f549-e790-4e9f-aa16-18c2292a2ee9", "Conferences" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "ee272f8b-6096-4cb6-8625-bb4bb2d89e8b", "John Egbert", "b0788d2f-8003-43c1-92a4-edc76a7c5dde", "2021-06-27T15:16:25.3351910+09:00", "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg", "John Egbert Live", 65 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "3448d5a4-0f72-4dd7-bf15-c14a46b26c00", "Michael Johnson", "b0788d2f-8003-43c1-92a4-edc76a7c5dde", "2021-09-27T15:16:25.3385450+09:00", "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg", "The State of Affairs: Michael Live!", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "b419a7ca-3321-4f38-be8e-4d7b6a529319", "DJ 'The Mike'", "b0788d2f-8003-43c1-92a4-edc76a7c5dde", "2021-04-27T15:16:25.3385590+09:00", "DJs from all over the world will compete in this epic battle for eternal fame.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg", "Clash of the DJs", 85 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "62787623-4c52-43fe-b0c9-b7044fb5929b", "Manuel Santinonisi", "b0788d2f-8003-43c1-92a4-edc76a7c5dde", "2021-04-27T15:16:25.3385630+09:00", "Get on the hype of Spanish Guitar concerts with Manuel.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg", "Spanish guitar hits with Manuel", 25 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "adc42c09-08c1-4d2c-9f96-2d15bb1af299", "Nick Sailor", "6313179f-7837-473a-a4d5-a5571b43e6a6", "2021-08-27T15:16:25.3385700+09:00", "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg", "To the Moon and Back", 135 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Artist", "CategoryId", "Date", "Description", "ImageUrl", "Name", "Price" },
                values: new object[] { "1babd057-e980-4cb3-9cd2-7fdd9e525668", "Many", "fe98f549-e790-4e9f-aa16-18c2292a2ee9", "2021-10-27T15:16:25.3385660+09:00", "The best tech conference in the world", "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg", "Techorama 2021", 400 });

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
