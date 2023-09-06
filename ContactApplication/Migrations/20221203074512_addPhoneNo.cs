using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApplication.Migrations
{
    public partial class addPhoneNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "FavouriteContact",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "Contact",
                type: "varchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "FavouriteContact");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "Contact");
        }
    }
}
