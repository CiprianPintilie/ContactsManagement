using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class MoveContactAddressToContactEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Address_AddressId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_AddressId",
                table: "Contact");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "Contact",
                newName: "StreetNumber");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostCode",
                table: "Contact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Address",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ContactId",
                table: "Address",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Contact_ContactId",
                table: "Address",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Contact_ContactId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ContactId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                table: "Contact",
                newName: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AddressId",
                table: "Contact",
                column: "AddressId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Address_AddressId",
                table: "Contact",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
