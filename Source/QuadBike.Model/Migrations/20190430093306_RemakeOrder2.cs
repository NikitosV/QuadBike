using Microsoft.EntityFrameworkCore.Migrations;

namespace QuadBike.Model.Migrations
{
    public partial class RemakeOrder2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderTotal",
                table: "Order",
                nullable: false,
                defaultValue: 0);
        }
    }
}
