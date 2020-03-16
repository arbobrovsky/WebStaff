using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ADdDecreetry5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecreeStaffs");

            migrationBuilder.DropTable(
                name: "Decrees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decrees",
                columns: table => new
                {
                    DecreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(nullable: false),
                    DecreeTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decrees", x => x.DecreeId);
                });

            migrationBuilder.CreateTable(
                name: "DecreeStaffs",
                columns: table => new
                {
                    DecreeStaffsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DecreeId = table.Column<int>(nullable: false),
                    FiredId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_DecreeId",
                table: "DecreeStaffs",
                column: "DecreeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecreeStaffs_FiredId",
                table: "DecreeStaffs",
                column: "FiredId");
        }
    }
}
