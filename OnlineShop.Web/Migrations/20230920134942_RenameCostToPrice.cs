using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShop.Web.Migrations
{
    public partial class RenameCostToPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Products",
                newName: "Price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "Cost");
        }
    }
}
