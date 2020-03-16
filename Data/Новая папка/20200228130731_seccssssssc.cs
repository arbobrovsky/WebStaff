using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seccssssssc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Departments_DepartmenId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DepartmenId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DepartmenId",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmenId",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DepartmenId",
                table: "Staffs",
                column: "DepartmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmenId",
                table: "Staffs",
                column: "DepartmenId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
