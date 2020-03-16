using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Decrees_Fireds_FiredId",
                table: "Decrees");

            migrationBuilder.DropForeignKey(
                name: "FK_Decrees_Staffs_StaffId",
                table: "Decrees");

            migrationBuilder.DropIndex(
                name: "IX_Decrees_FiredId",
                table: "Decrees");

            migrationBuilder.DropIndex(
                name: "IX_Decrees_StaffId",
                table: "Decrees");

            migrationBuilder.DropColumn(
                name: "FiredId",
                table: "Decrees");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Decrees");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Decrees");

            migrationBuilder.RenameColumn(
                name: "СommandTime",
                table: "Decrees",
                newName: "DecreeTime");

            migrationBuilder.AddColumn<int>(
                name: "DecreeId",
                table: "Staffs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Decrees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DecreeStaffs",
                columns: table => new
                {
                    DecreeStaffsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    DecreeId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    FiredId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecreeStaffs", x => x.DecreeStaffsId);
                    table.ForeignKey(
                        name: "FK_DecreeStaffs_Decrees_DecreeId",
                        column: x => x.DecreeId,
                        principalTable: "Decrees",
                        principalColumn: "DecreeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DecreeStaffs_Fireds_FiredId",
                        column: x => x.FiredId,
                        principalTable: "Fireds",
                        principalColumn: "FiredId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DecreeStaffs_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DecreeId",
                table: "Staffs",
                column: "DecreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_DecreeId",
                table: "DecreeStaffs",
                column: "DecreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_FiredId",
                table: "DecreeStaffs",
                column: "FiredId");

            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_StaffId",
                table: "DecreeStaffs",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Decrees_DecreeId",
                table: "Staffs",
                column: "DecreeId",
                principalTable: "Decrees",
                principalColumn: "DecreeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Decrees_DecreeId",
                table: "Staffs");

            migrationBuilder.DropTable(
                name: "DecreeStaffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_DecreeId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "DecreeId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Decrees");

            migrationBuilder.RenameColumn(
                name: "DecreeTime",
                table: "Decrees",
                newName: "СommandTime");

            migrationBuilder.AddColumn<int>(
                name: "FiredId",
                table: "Decrees",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Decrees",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Decrees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_FiredId",
                table: "Decrees",
                column: "FiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_StaffId",
                table: "Decrees",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Decrees_Fireds_FiredId",
                table: "Decrees",
                column: "FiredId",
                principalTable: "Fireds",
                principalColumn: "FiredId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Decrees_Staffs_StaffId",
                table: "Decrees",
                column: "StaffId",
                principalTable: "Staffs",
                principalColumn: "StaffId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
