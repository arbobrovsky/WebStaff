using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class numberpricaz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DecreeNumber",
                table: "Decrees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecreeNumber",
                table: "Decrees");
        }
    }
}
