using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecreetry3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DecreeStaffs_Staffs_StaffId",
                table: "DecreeStaffs");

            migrationBuilder.DropIndex(
                name: "IX_DecreeStaffs_StaffId",
                table: "DecreeStaffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_StaffId",
                table: "DecreeStaffs",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_DecreeStaffs_Staffs_StaffId",
                table: "DecreeStaffs",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
