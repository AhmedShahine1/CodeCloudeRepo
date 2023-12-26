using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCloude.Migrations
{
    public partial class addFaviorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Favourites_FavouritesId",
                table: "Stores");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Stores_FavouritesId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "FavouritesId",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "BankDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    accountNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscripeRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscripeRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscripeRequests_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscripeRequests_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_Faviourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    storeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Faviourites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Faviourites_Stores_storeId",
                        column: x => x.storeId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscripeRequests_ApplicationUserId",
                table: "SubscripeRequests",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscripeRequests_SubscriptionId",
                table: "SubscripeRequests",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Faviourites_storeId",
                table: "User_Faviourites",
                column: "storeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankDetails");

            migrationBuilder.DropTable(
                name: "SubscripeRequests");

            migrationBuilder.DropTable(
                name: "User_Faviourites");

            migrationBuilder.AddColumn<int>(
                name: "FavouritesId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stores_FavouritesId",
                table: "Stores",
                column: "FavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Favourites_FavouritesId",
                table: "Stores",
                column: "FavouritesId",
                principalTable: "Favourites",
                principalColumn: "Id");
        }
    }
}
