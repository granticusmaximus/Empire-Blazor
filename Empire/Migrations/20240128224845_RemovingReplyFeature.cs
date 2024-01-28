using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Migrations
{
    public partial class RemovingReplyFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Notes_ParentCommentId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ParentCommentId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                table: "Notes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ParentCommentId",
                table: "Notes",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Notes_ParentCommentId",
                table: "Notes",
                column: "ParentCommentId",
                principalTable: "Notes",
                principalColumn: "Id");
        }
    }
}
