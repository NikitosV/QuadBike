using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuadBike.Model.Migrations
{
    public partial class RemakeOrder4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Order",
                newName: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Order",
                newName: "OrderId");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(nullable: true),
                    AccountProviderId = table.Column<string>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    BikeId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    OrderLines = table.Column<int>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Bike_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Order_OrderLines",
                        column: x => x.OrderLines,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AccountId",
                table: "OrderDetails",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_BikeId",
                table: "OrderDetails",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderLines",
                table: "OrderDetails",
                column: "OrderLines");
        }
    }
}
