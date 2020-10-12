using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebApp.Database.Migrations
{
    public partial class RemoveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Column2",
                table: "Entities1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Column2",
                table: "Entities1",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
