using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddMainAddressToCompanyEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainCity",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainCountry",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainPostCode",
                table: "Company",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MainStreet",
                table: "Company",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MainStreetNumber",
                table: "Company",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainCity",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "MainCountry",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "MainPostCode",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "MainStreet",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "MainStreetNumber",
                table: "Company");
        }
    }
}
