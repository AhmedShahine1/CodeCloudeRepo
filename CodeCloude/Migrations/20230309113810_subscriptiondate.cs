using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCloude.Migrations
{
    public partial class subscriptiondate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionDate",
                table: "UserSubscription",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscriptionDate",
                table: "UserSubscription");
        }
    }
}
