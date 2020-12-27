using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShowBiz.Migrations
{
    public partial class initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Release = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Duration = table.Column<TimeSpan>(nullable: true),
                    EpisodeCounts = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ActorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductionId = table.Column<int>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    Source = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Robert Downey Jr." });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 18, "Melissa McBride" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 17, "Norman Reedus" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 16, "Hazuki Shimizu" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 15, "Matsuya Onoe" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Winona Ryder" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 12, "Caleb McLaughlin" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 11, "Millie Bobby Brown" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 10, "Karyn Parsons" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 14, "David Harbour" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "Maggie Smith" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Will Smith" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "Donny Yen" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Beyoncé" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Donald Glover" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Danai Guira" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Chris Evans" });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[] { 9, "Michelle Dockery" });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "EpisodeCounts" },
                values: new object[] { 8, "Series", "Stranger Things", new DateTime(2016, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 34 });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "EpisodeCounts" },
                values: new object[] { 7, "Series", "Downton Abbey", new DateTime(2010, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 52 });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "EpisodeCounts" },
                values: new object[] { 6, "Series", "The Fresh Prince of Bel-Air", new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 148 });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "Duration" },
                values: new object[] { 5, "Movie", "Downton Abbey", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 2, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "Duration" },
                values: new object[] { 1, "Movie", "Avengers: Endgame", new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 3, 1, 0, 0) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "Duration" },
                values: new object[] { 3, "Movie", "Ip Man 4", new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 45, 0, 0) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "Duration" },
                values: new object[] { 2, "Movie", "The Lion King", new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 58, 0, 0) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "EpisodeCounts" },
                values: new object[] { 9, "Series", "Kantaro: The Sweet Tooth Salaryman", new DateTime(2017, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "Duration" },
                values: new object[] { 4, "Movie", "Gemini Man", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 56, 0, 0) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "Release", "EpisodeCounts" },
                values: new object[] { 10, "Series", "The Walking Dead", new DateTime(2010, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 177 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 1, 1, "Tony Stark", 1 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 6, 6, "Ip Man", 3 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 7, 7, "Henry Brogan", 4 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 8, 8, "Violet Crawley", 5 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 9, 9, "Lady Mary Crawley", 5 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 10, 7, "Will Smith", 6 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 12, 8, "Violet Crawley", 7 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 13, 9, "Lady Mary Crawley", 7 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 5, 5, "Nala", 2 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 14, 11, "Eleven", 8 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 16, 13, "Joyce Byers", 8 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 17, 14, "Jim Hopper", 8 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 18, 15, "Ametani Kantarou", 9 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 19, 16, "Sano Erika", 9 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 20, 17, "Daryl Dixon", 10 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 21, 3, "Michonne", 10 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 22, 18, "Carol Peletier", 10 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 15, 12, "Lucas", 8 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 4, 4, "Simba", 2 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 11, 10, "Hilary Banks", 6 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 2, 2, "Steve Rogers", 1 });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[] { 3, 3, "Okoye", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 18, 1, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 666, 7, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 667, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 668, 7, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 669, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 670, 7, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 671, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 672, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 673, 7, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 674, 7, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 675, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 676, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 665, 7, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 677, 7, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 679, 7, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 680, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 681, 7, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 682, 7, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 683, 7, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 684, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 685, 7, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 686, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 687, 7, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 688, 7, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 689, 7, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 690, 7, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 691, 7, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 678, 7, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 664, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 663, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 662, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 636, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 637, 7, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 638, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 639, 7, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 640, 7, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 641, 7, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 642, 7, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 643, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 644, 7, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 645, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 646, 7, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 647, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 692, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 648, 7, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 650, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 651, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 652, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 653, 7, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 654, 7, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 655, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 656, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 657, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 658, 7, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 659, 7, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 660, 7, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 661, 7, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 649, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 693, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 694, 7, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 695, 7, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 725, 8, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 726, 8, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 727, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 728, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 729, 8, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 730, 8, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 731, 8, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 732, 8, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 733, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 734, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 735, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 736, 8, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 737, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 738, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 739, 8, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 740, 8, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 741, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 742, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 743, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 744, 8, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 745, 8, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 746, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 747, 8, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 748, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 749, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 750, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 751, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 724, 8, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 723, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 722, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 721, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 696, 7, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 697, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 698, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 699, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 7, 1, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 6, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 5, 1, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 4, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 701, 8, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 702, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 703, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 704, 8, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 705, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 635, 7, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 706, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 708, 8, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 709, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 710, 8, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 711, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 712, 8, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 713, 8, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 714, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 715, 8, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 716, 8, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 717, 8, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 718, 8, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 719, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 720, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 707, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 634, 7, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 632, 7, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 752, 8, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 544, 6, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 545, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 546, 6, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 547, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 548, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 549, 6, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 550, 6, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 551, 6, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 552, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 553, 6, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 554, 6, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 555, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 556, 6, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 557, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 558, 6, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 559, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 560, 6, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 561, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 562, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 563, 6, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 564, 6, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 565, 6, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 566, 6, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 567, 6, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 568, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 569, 6, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 570, 6, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 543, 6, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 571, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 542, 6, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 540, 6, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 513, 6, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 514, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 515, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 516, 6, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 517, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 518, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 519, 6, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 520, 6, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 521, 6, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 522, 6, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 523, 6, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 524, 6, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 525, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 526, 6, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 527, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 528, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 529, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 530, 6, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 531, 6, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 532, 6, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 533, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 534, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 535, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 536, 6, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 537, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 538, 6, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 539, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 541, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 633, 7, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 572, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 574, 6, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 605, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 606, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 607, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 608, 7, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 609, 7, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 610, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 611, 7, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 612, 7, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 613, 7, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 614, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 615, 7, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 616, 7, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 617, 7, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 618, 7, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 619, 7, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 620, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 621, 7, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 622, 7, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 623, 7, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 624, 7, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 625, 7, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 626, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 627, 7, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 628, 7, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 629, 7, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 630, 7, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 631, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 604, 7, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 573, 6, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 603, 7, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 601, 7, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 575, 6, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 576, 6, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 577, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 578, 6, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 579, 6, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 580, 6, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 581, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 582, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 583, 6, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 584, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 585, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 586, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 587, 6, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 588, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 589, 6, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 590, 6, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 591, 6, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 592, 6, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 593, 6, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 594, 6, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 595, 6, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 596, 6, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 597, 6, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 598, 6, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 599, 6, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 9, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 8, 1, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 602, 7, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 753, 8, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 754, 8, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 755, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 910, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 911, 10, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 912, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 913, 10, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 914, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 915, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 916, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 917, 10, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 918, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 919, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 920, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 921, 10, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 909, 10, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 922, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 924, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 925, 10, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 926, 10, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 927, 10, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 928, 10, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 929, 10, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 930, 10, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 931, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 932, 10, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 933, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 934, 10, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 935, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 923, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 908, 10, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 907, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 906, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 879, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 880, 9, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 881, 9, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 882, 9, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 883, 9, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 884, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 885, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 886, 9, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 887, 9, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 888, 9, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 889, 9, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 890, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 891, 9, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 892, 9, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 893, 9, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 894, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 895, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 896, 9, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 897, 9, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 898, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 899, 9, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 1, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 901, 10, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 902, 10, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 903, 10, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 904, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 905, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 936, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 937, 10, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 938, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 939, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 971, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 972, 10, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 973, 10, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 974, 10, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 975, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 976, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 977, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 978, 10, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 979, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 980, 10, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 981, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 982, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 983, 10, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 984, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 985, 10, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 986, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 987, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 988, 10, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 989, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 990, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 991, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 992, 10, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 993, 10, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 994, 10, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 995, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 996, 10, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 997, 10, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 970, 10, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 878, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 969, 10, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 967, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 940, 10, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 941, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 942, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 943, 10, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 944, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 945, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 946, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 947, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 948, 10, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 949, 10, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 950, 10, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 951, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 952, 10, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 953, 10, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 954, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 955, 10, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 956, 10, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 957, 10, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 958, 10, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 959, 10, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 960, 10, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 961, 10, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 962, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 963, 10, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 964, 10, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 965, 10, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 966, 10, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 968, 10, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 877, 9, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 876, 9, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 875, 9, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 787, 8, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 788, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 789, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 790, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 791, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 792, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 793, 8, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 794, 8, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 795, 8, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 796, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 797, 8, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 798, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 799, 8, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 3, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 2, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 801, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 802, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 803, 9, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 804, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 805, 9, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 806, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 807, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 808, 9, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 809, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 810, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 811, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 812, 9, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 786, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 813, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 785, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 783, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 756, 8, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 757, 8, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 758, 8, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 759, 8, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 760, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 761, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 762, 8, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 763, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 764, 8, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 765, 8, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 766, 8, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 767, 8, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 768, 8, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 769, 8, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 770, 8, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 771, 8, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 772, 8, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 773, 8, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 774, 8, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 775, 8, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 776, 8, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 777, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 778, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 779, 8, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 780, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 781, 8, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 782, 8, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 784, 8, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 512, 6, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 814, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 816, 9, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 848, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 849, 9, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 850, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 851, 9, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 852, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 853, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 854, 9, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 855, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 856, 9, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 857, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 858, 9, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 859, 9, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 860, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 861, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 862, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 863, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 864, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 865, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 866, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 867, 9, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 868, 9, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 869, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 870, 9, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 871, 9, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 872, 9, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 873, 9, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 874, 9, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 847, 9, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 815, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 846, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 844, 9, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 817, 9, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 818, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 819, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 820, 9, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 821, 9, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 822, 9, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 823, 9, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 824, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 825, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 826, 9, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 827, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 828, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 829, 9, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 830, 9, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 831, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 832, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 833, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 834, 9, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 835, 9, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 836, 9, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 837, 9, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 838, 9, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 839, 9, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 840, 9, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 841, 9, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 842, 9, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 843, 9, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 845, 9, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 511, 6, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 510, 6, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 509, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 173, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 174, 2, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 175, 2, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 176, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 177, 2, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 178, 2, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 179, 2, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 180, 2, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 181, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 182, 2, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 183, 2, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 184, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 185, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 186, 2, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 187, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 188, 2, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 189, 2, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 190, 2, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 191, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 192, 2, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 193, 2, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 194, 2, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 195, 2, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 196, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 197, 2, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 198, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 199, 2, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 172, 2, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 14, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 171, 2, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 169, 2, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 142, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 143, 2, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 144, 2, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 145, 2, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 146, 2, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 147, 2, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 148, 2, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 149, 2, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 150, 2, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 151, 2, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 152, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 153, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 154, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 155, 2, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 156, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 157, 2, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 158, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 159, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 160, 2, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 161, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 162, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 163, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 164, 2, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 165, 2, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 166, 2, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 167, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 168, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 170, 2, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 141, 2, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 201, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 203, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 235, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 236, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 237, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 238, 3, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 239, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 240, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 241, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 242, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 243, 3, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 244, 3, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 245, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 246, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 247, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 248, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 249, 3, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 250, 3, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 251, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 252, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 253, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 254, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 255, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 256, 3, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 257, 3, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 258, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 259, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 260, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 261, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 234, 3, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 202, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 233, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 231, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 204, 3, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 205, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 206, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 207, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 208, 3, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 209, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 210, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 211, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 212, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 213, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 214, 3, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 215, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 216, 3, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 217, 3, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 218, 3, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 219, 3, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 220, 3, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 221, 3, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 222, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 223, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 224, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 225, 3, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 226, 3, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 227, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 228, 3, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 229, 3, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 230, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 232, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 262, 3, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 140, 2, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 138, 2, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 50, 1, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 51, 1, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 52, 1, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 53, 1, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 54, 1, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 55, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 56, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 57, 1, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 58, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 59, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 60, 1, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 61, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 62, 1, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 63, 1, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 64, 1, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 65, 1, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 66, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 67, 1, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 68, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 69, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 70, 1, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 71, 1, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 72, 1, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 73, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 74, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 75, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 76, 1, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 49, 1, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 77, 1, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 48, 1, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 46, 1, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 19, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 20, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 21, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 22, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 23, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 24, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 25, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 26, 1, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 27, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 28, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 29, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 30, 1, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 31, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 32, 1, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 33, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 34, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 35, 1, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 36, 1, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 37, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 38, 1, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 39, 1, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 40, 1, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 41, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 42, 1, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 43, 1, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 44, 1, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 45, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 47, 1, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 139, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 78, 1, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 80, 1, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 111, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 112, 2, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 113, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 114, 2, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 115, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 116, 2, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 117, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 118, 2, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 119, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 120, 2, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 121, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 122, 2, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 123, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 124, 2, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 125, 2, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 126, 2, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 127, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 128, 2, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 129, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 130, 2, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 131, 2, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 132, 2, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 133, 2, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 134, 2, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 135, 2, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 136, 2, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 137, 2, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 110, 2, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 79, 1, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 109, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 107, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 81, 1, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 82, 1, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 83, 1, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 84, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 85, 1, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 86, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 87, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 88, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 89, 1, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 90, 1, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 91, 1, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 92, 1, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 93, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 94, 1, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 95, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 96, 1, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 97, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 98, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 99, 1, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 16, 1, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 15, 1, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 101, 2, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 102, 2, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 103, 2, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 104, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 105, 2, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 106, 2, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 108, 2, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 263, 3, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 264, 3, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 265, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 421, 5, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 422, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 423, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 424, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 425, 5, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 426, 5, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 427, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 428, 5, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 429, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 430, 5, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 431, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 432, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 433, 5, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 434, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 435, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 436, 5, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 437, 5, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 438, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 439, 5, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 440, 5, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 441, 5, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 442, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 443, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 444, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 445, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 446, 5, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 447, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 420, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 448, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 419, 5, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 417, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 391, 4, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 392, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 393, 4, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 394, 4, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 395, 4, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 396, 4, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 397, 4, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 398, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 399, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 12, 1, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 11, 1, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 401, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 402, 5, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 403, 5, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 404, 5, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 405, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 406, 5, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 407, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 408, 5, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 409, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 410, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 411, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 412, 5, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 413, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 414, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 415, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 416, 5, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 418, 5, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 390, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 449, 5, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 451, 5, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 483, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 484, 5, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 485, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 486, 5, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 487, 5, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 488, 5, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 489, 5, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 490, 5, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 491, 5, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 492, 5, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 493, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 494, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 495, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 496, 5, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 497, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 498, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 499, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 10, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 998, 10, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 501, 6, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 502, 6, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 503, 6, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 504, 6, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 505, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 506, 6, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 507, 6, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 508, 6, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 482, 5, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 450, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 481, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 479, 5, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 452, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 453, 5, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 454, 5, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 455, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 456, 5, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 457, 5, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 458, 5, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 459, 5, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 460, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 461, 5, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 462, 5, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 463, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 464, 5, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 465, 5, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 466, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 467, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 468, 5, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 469, 5, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 470, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 471, 5, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 472, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 473, 5, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 474, 5, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 475, 5, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 476, 5, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 477, 5, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 478, 5, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 480, 5, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 389, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 388, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 387, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 297, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 298, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 299, 3, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 13, 1, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 301, 4, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 302, 4, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 303, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 304, 4, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 305, 4, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 306, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 307, 4, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 308, 4, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 309, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 310, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 311, 4, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 312, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 313, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 314, 4, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 315, 4, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 316, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 317, 4, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 318, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 319, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 320, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 321, 4, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 322, 4, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 323, 4, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 296, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 324, 4, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 295, 3, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 293, 3, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 266, 3, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 267, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 268, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 269, 3, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 270, 3, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 271, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 272, 3, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 273, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 274, 3, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 275, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 276, 3, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 277, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 278, 3, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 279, 3, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 280, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 281, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 282, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 283, 3, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 284, 3, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 285, 3, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 286, 3, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 287, 3, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 288, 3, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 289, 3, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 290, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 291, 3, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 292, 3, "Newspaper", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 294, 3, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 325, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 326, 4, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 327, 4, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 360, 4, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 361, 4, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 362, 4, "App", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 363, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 364, 4, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 365, 4, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 366, 4, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 367, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 368, 4, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 369, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 370, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 371, 4, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 372, 4, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 373, 4, "Internet", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 374, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 375, 4, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 376, 4, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 377, 4, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 378, 4, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 379, 4, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 380, 4, "Magazine", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 381, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 382, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 383, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 384, 4, "App", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 385, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 386, 4, "Newspaper", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 359, 4, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 358, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 357, 4, "Newspaper", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 356, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 328, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 329, 4, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 330, 4, "App", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 331, 4, "Magazine", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 332, 4, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 333, 4, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 334, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 335, 4, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 336, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 337, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 338, 4, "App", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 339, 4, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 340, 4, "Magazine", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 17, 1, "Magazine", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 341, 4, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 343, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 344, 4, "Internet", 3 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 345, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 346, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 347, 4, "Internet", 4 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 348, 4, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 349, 4, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 350, 4, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 351, 4, "Newspaper", 1 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 352, 4, "Newspaper", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 353, 4, "Magazine", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 354, 4, "Internet", 5 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 355, 4, "Internet", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 342, 4, "App", 2 });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[] { 999, 10, "Magazine", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ProductionId",
                table: "Characters",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductionId",
                table: "Ratings",
                column: "ProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Productions");
        }
    }
}
