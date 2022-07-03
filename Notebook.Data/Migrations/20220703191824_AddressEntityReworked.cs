using Microsoft.EntityFrameworkCore.Migrations;

namespace Notebook.Data.Migrations
{
    public partial class AddressEntityReworked : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Address_Index",
                table: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Address_Index",
                table: "Address",
                column: "Index",
                unique: true);
        }
    }
}
