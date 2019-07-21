using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravellerCore.Migrations
{
    public partial class Unit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameCountry = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCountry = table.Column<int>(nullable: true),
                    IdPicture = table.Column<int>(nullable: true),
                    NameHotel = table.Column<string>(nullable: true),
                    AboutHotel = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamePicture = table.Column<string>(nullable: true),
                    IdHotel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tour",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdHotel = table.Column<int>(nullable: true),
                    DateArrival = table.Column<DateTime>(nullable: true),
                    AmountDay = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tour", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "NameCountry" },
                values: new object[,]
                {
                    { 1, "Italy" },
                    { 2, "England" },
                    { 3, "Egipt" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "Id", "AboutHotel", "IdCountry", "IdPicture", "NameHotel", "Price" },
                values: new object[,]
                {
                    { 1, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", 1, 1, "Venecia", 75m },
                    { 2, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", 1, 3, "Rome", 150m },
                    { 3, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", 2, 4, "Washington", 100m },
                    { 4, "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", 2, 5, "London", 112m }
                });

            migrationBuilder.InsertData(
                table: "Picture",
                columns: new[] { "Id", "IdHotel", "NamePicture" },
                values: new object[,]
                {
                    { 5, 4, "../images/serd.png" },
                    { 4, 3, "../images/serd.png" },
                    { 2, 1, "../images/serd.png" },
                    { 1, 1, "../images/legak.png" },
                    { 3, 2, "../images/legak.png" }
                });

            migrationBuilder.InsertData(
                table: "Tour",
                columns: new[] { "Id", "AmountDay", "DateArrival", "IdHotel" },
                values: new object[,]
                {
                    { 4, 14, new DateTime(2019, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 1, 12, new DateTime(2019, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 10, new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 12, new DateTime(2019, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 5, 10, new DateTime(2019, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Tour");
        }
    }
}
