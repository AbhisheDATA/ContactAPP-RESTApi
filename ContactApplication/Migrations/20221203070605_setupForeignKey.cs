using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApplication.Migrations
{
    public partial class setupForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_FavouriteContact_Contact_Id",
                table: "FavouriteContact",
                column: "Id",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavouriteContact_Contact_Id",
                table: "FavouriteContact");
        }
    }
}
