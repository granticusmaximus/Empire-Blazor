using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Data.Migrations
{
    public partial class RemovalOfDedveloperAndAnalystModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Analyst_AssignedBA",
                table: "Apps");

            migrationBuilder.DropForeignKey(
                name: "FK_Apps_Developer_AssignedDev",
                table: "Apps");

            migrationBuilder.DropTable(
                name: "Analyst");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropIndex(
                name: "IX_Apps_AssignedBA",
                table: "Apps");

            migrationBuilder.DropIndex(
                name: "IX_Apps_AssignedDev",
                table: "Apps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Analyst",
                columns: table => new
                {
                    BAID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BAFName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BALName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyst", x => x.BAID);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedBA",
                table: "Apps",
                column: "AssignedBA");

            migrationBuilder.CreateIndex(
                name: "IX_Apps_AssignedDev",
                table: "Apps",
                column: "AssignedDev");

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Analyst_AssignedBA",
                table: "Apps",
                column: "AssignedBA",
                principalTable: "Analyst",
                principalColumn: "BAID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Apps_Developer_AssignedDev",
                table: "Apps",
                column: "AssignedDev",
                principalTable: "Developer",
                principalColumn: "DevID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
