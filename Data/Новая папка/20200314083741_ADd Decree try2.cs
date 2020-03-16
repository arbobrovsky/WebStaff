using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecreetry2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Decrees_DecreeId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DecreeId",
                table: "Staffs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DecreeId",
                table: "Staffs",
                column: "DecreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Decrees_DecreeId",
                table: "Staffs",
                column: "DecreeId",
                principalTable: "Decrees",
                principalColumn: "DecreeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
