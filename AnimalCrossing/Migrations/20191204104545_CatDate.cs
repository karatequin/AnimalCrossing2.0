using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalCrossing.Migrations
{
    public partial class CatDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatDates",
                columns: table => new
                {
                    CatDateId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HostId = table.Column<int>(nullable: false),
                    HostCatCatId = table.Column<int>(nullable: true),
                    GuestId = table.Column<int>(nullable: false),
                    GuestCatCatId = table.Column<int>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDates", x => x.CatDateId);
                    table.ForeignKey(
                        name: "FK_CatDates_Cats_GuestCatCatId",
                        column: x => x.GuestCatCatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatDates_Cats_HostCatCatId",
                        column: x => x.HostCatCatId,
                        principalTable: "Cats",
                        principalColumn: "CatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CatDates_GuestCatCatId",
                table: "CatDates",
                column: "GuestCatCatId");

            migrationBuilder.CreateIndex(
                name: "IX_CatDates_HostCatCatId",
                table: "CatDates",
                column: "HostCatCatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatDates");
        }
    }
}
