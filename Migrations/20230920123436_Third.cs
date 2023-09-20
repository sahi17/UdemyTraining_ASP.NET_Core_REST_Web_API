using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyTraining_ASP.NET_Core_REST_Web_API.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Create",
                table: "Restaurants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Create",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
