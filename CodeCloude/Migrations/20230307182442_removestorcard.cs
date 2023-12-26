using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeCloude.Migrations
{
    public partial class removestorcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accept_Loco_Card",
                table: "Stores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Accept_Loco_Card",
                table: "Stores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
