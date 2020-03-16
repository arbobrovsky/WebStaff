using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seccssssc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Fired",
                table: "Staffs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fired",
                table: "Staffs");
        }
    }
}
