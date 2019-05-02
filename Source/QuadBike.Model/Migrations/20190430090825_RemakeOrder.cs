using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuadBike.Model.Migrations
{
    public partial class RemakeOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentBike");

            migrationBuilder.DropTable(
                name: "RentTrip");

            migrationBuilder.AddColumn<string>(
                name: "AccountId",
                table: "OrderDetails",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_AccountId",
                table: "OrderDetails",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_AspNetUsers_AccountId",
                table: "OrderDetails",
                column: "AccountId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_AspNetUsers_AccountId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_AccountId",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "OrderDetails");

            migrationBuilder.CreateTable(
                name: "RentBike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(nullable: true),
                    BikeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentBike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentBike_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentBike_Bike_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bike",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RentTrip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccountId = table.Column<string>(nullable: true),
                    TripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTrip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentTrip_AspNetUsers_AccountId",
                        column: x => x.AccountId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RentTrip_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentBike_AccountId",
                table: "RentBike",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RentBike_BikeId",
                table: "RentBike",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_RentTrip_AccountId",
                table: "RentTrip",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_RentTrip_TripId",
                table: "RentTrip",
                column: "TripId");
        }
    }
}
