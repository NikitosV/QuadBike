using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuadBike.Model.Migrations
{
    public partial class RemOrderDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_AccountId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Bike_BikeId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_AccountId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_BikeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "AccountProviderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "BikeId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Order");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    AccountProviderId = table.Column<string>(nullable: true),
                    BikeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Bike_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BikeId",
                table: "OrderDetails",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountProviderId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BikeId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_AccountId",
                table: "Order",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_BikeId",
                table: "Order",
                column: "BikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_AccountId",
                table: "Order",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Bike_BikeId",
                table: "Order",
                column: "BikeId",
                principalTable: "Bike",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
