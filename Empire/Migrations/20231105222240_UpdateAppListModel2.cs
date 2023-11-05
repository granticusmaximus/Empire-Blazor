using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Migrations
{
    public partial class UpdateAppListModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDev",
                table: "Apps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedDev",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
