using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class addcommandstry3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Сommands");

            migrationBuilder.CreateTable(
                name: "Decrees",
                columns: table => new
                {
                    DecreeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    FiredId = table.Column<int>(nullable: true),
                    СommandTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decrees", x => x.DecreeId);
                    table.ForeignKey(
                        name: "FK_Decrees_Fireds_FiredId",
                        column: x => x.FiredId,
                        principalTable: "Fireds",
                        principalColumn: "FiredId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Decrees_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_FiredId",
                table: "Decrees",
                column: "FiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Decrees_StaffId",
                table: "Decrees",
                column: "StaffId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Decrees");

            migrationBuilder.CreateTable(
                name: "Сommands",
                columns: table => new
                {
                    СommandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FiredId = table.Column<int>(nullable: true),
                    StaffId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    СommandTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Сommands", x => x.СommandId);
                    table.ForeignKey(
                        name: "FK_Сommands_Fireds_FiredId",
                        column: x => x.FiredId,
                        principalTable: "Fireds",
                        principalColumn: "FiredId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Сommands_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Сommands_FiredId",
                table: "Сommands",
                column: "FiredId");

            migrationBuilder.CreateIndex(
                name: "IX_Сommands_StaffId",
                table: "Сommands",
                column: "StaffId");
        }
    }
}
