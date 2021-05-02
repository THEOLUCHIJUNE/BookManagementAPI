using Microsoft.EntityFrameworkCore.Migrations;

namespace BookManagementAPI.Migrations
{
    public partial class UpdatePublisherModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Publishers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Publishers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Publishers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Publishers");
        }
    }
}
