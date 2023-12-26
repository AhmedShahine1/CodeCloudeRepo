using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCloude.Migrations
{
    public partial class remocelocoviocard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "UserSubscription",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stor_Address",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_ApplicationUserId",
                table: "UserSubscription",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSubscription_SubscriptionId",
                table: "UserSubscription",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSubscription_Subscriptions_SubscriptionId",
                table: "UserSubscription",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscription_AspNetUsers_ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSubscription_Subscriptions_SubscriptionId",
                table: "UserSubscription");

            migrationBuilder.DropIndex(
                name: "IX_UserSubscription_ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropIndex(
                name: "IX_UserSubscription_SubscriptionId",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "UserSubscription");

            migrationBuilder.DropColumn(
                name: "Stor_Address",
                table: "Stores");
        }
    }
}
