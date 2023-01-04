using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DelabinService.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    tags = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    someData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fieldData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Documentid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.id);
                    table.ForeignKey(
                        name: "FK_Data_Documents_Documentid",
                        column: x => x.Documentid,
                        principalTable: "Documents",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_Documentid",
                table: "Data",
                column: "Documentid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "Documents");
        }
    }
}
