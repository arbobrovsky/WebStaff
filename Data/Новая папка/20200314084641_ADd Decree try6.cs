using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecreetry6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecreeId",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecreeId",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
