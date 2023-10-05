using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Data.Migrations
{
    public partial class AppListAndDeveloperEntityCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    DevID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DevFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DevLName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.DevID);
                });

            migrationBuilder.CreateTable(
                name: "Apps",
                columns: table => new
                {
                    AppID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignedBA = table.Column<int>(type: "int", nullable: false),
                    AssignedDev = table.Column<int>(type: "int", nullable: false),
                    AppNotes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    POCEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apps", x => x.AppID);
                    table.ForeignKey(
                        name: "FK_Apps_Analyst_AssignedBA",
                        column: x => x.AssignedBA,
                        principalTable: "Analyst",
                        principalColumn: "BAID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apps_Developer_AssignedDev",
                        column: x => x.AssignedDev,
                        principalTable: "Developer",
                        principalColumn: "DevID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedBA",
                table: "Apps",
                column: "AssignedBA");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedDev",
                table: "Apps",
                column: "AssignedDev");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apps");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
