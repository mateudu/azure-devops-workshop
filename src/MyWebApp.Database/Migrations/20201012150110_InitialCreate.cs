using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApp.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entities1",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Column1 = table.Column<string>(nullable: true),
                    Column2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities1", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entities1");
        }
    }
}
