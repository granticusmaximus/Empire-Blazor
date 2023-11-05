using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Migrations
{
    public partial class UpdateAppListModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedBA",
                table: "Apps");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedBA",
                table: "Apps",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
