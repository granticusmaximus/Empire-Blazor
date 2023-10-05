using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Data.Migrations
{
    public partial class MSRTaskEntityCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    MsrID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedEmpID = table.Column<int>(type: "int", nullable: false),
                    AssignedAppID = table.Column<int>(type: "int", nullable: false),
                    AppsAppID = table.Column<int>(type: "int", nullable: false),
                    MSRtitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MSRNote = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.MsrID);
                    table.ForeignKey(
                        name: "FK_Tasks_Apps_AppsAppID",
                        column: x => x.AppsAppID,
                        principalTable: "Apps",
                        principalColumn: "AppID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Employee_AssignedEmpID",
                        column: x => x.AssignedEmpID,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AppsAppID",
                table: "Tasks",
                column: "AppsAppID");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_AssignedEmpID",
                table: "Tasks",
                column: "AssignedEmpID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
