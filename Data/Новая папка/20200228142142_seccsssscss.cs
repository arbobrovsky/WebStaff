using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class seccsssscss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Fireds_FiredId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_FiredId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "FiredId",
                table: "Staffs");

            migrationBuilder.AddColumn<string>(
                name: "HowFired",
                table: "Fireds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Fireds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fireds_StaffId",
                table: "Fireds",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fireds_Staffs_StaffId",
                table: "Fireds",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fireds_Staffs_StaffId",
                table: "Fireds");

            migrationBuilder.DropIndex(
                name: "IX_Fireds_StaffId",
                table: "Fireds");

            migrationBuilder.DropColumn(
                name: "HowFired",
                table: "Fireds");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Fireds");

            migrationBuilder.AddColumn<int>(
                name: "FiredId",
                table: "Staffs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_FiredId",
                table: "Staffs",
                column: "FiredId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Fireds_FiredId",
                table: "Staffs",
                column: "FiredId",
                principalTable: "Fireds",
                principalColumn: "FiredId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
