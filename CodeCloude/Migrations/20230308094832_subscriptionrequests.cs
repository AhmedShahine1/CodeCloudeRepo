using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCloude.Migrations
{
    public partial class subscriptionrequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserSubscription");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribed",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserSubscription",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
