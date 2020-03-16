using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecreetry7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fireds_Staffs_StaffId",
                table: "Fireds");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Positions_PositionId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Ranks_RankId",
                table: "Staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_SubDepartments_SubDepartmenId",
                table: "Staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDepartments",
                table: "SubDepartments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs");

            migrationBuilder.RenameTable(
                name: "SubDepartments",
                newName: "SubDepartment");

            migrationBuilder.RenameTable(
                name: "Staffs",
                newName: "Staff");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_SubDepartmenId",
                table: "Staff",
                newName: "IX_Staff_SubDepartmenId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_RankId",
                table: "Staff",
                newName: "IX_Staff_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_Staffs_PositionId",
                table: "Staff",
                newName: "IX_Staff_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDepartment",
                table: "SubDepartment",
                column: "SubDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staff",
                table: "Staff",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fireds_Staff_StaffId",
                table: "Fireds",
                column: "StaffId",
                principalTable: "Staff",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Positions_PositionId",
                table: "Staff",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Ranks_RankId",
                table: "Staff",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_SubDepartment_SubDepartmenId",
                table: "Staff",
                column: "SubDepartmenId",
                principalTable: "SubDepartment",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fireds_Staff_StaffId",
                table: "Fireds");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Positions_PositionId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Ranks_RankId",
                table: "Staff");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_SubDepartment_SubDepartmenId",
                table: "Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubDepartment",
                table: "SubDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Staff",
                table: "Staff");

            migrationBuilder.RenameTable(
                name: "SubDepartment",
                newName: "SubDepartments");

            migrationBuilder.RenameTable(
                name: "Staff",
                newName: "Staffs");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_SubDepartmenId",
                table: "Staffs",
                newName: "IX_Staffs_SubDepartmenId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_RankId",
                table: "Staffs",
                newName: "IX_Staffs_RankId");

            migrationBuilder.RenameIndex(
                name: "IX_Staff_PositionId",
                table: "Staffs",
                newName: "IX_Staffs_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubDepartments",
                table: "SubDepartments",
                column: "SubDepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Staffs",
                table: "Staffs",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fireds_Staffs_StaffId",
                table: "Fireds",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Positions_PositionId",
                table: "Staffs",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "PositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Ranks_RankId",
                table: "Staffs",
                column: "RankId",
                principalTable: "Ranks",
                principalColumn: "RankId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_SubDepartments_SubDepartmenId",
                table: "Staffs",
                column: "SubDepartmenId",
                principalTable: "SubDepartments",
                principalColumn: "SubDepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
