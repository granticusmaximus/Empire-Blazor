using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Migrations
{
    public partial class EFModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechNote_Notes_TechNoteId",
                table: "TicketTechNote");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechNote_Tickets_TicketId",
                table: "TicketTechNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTechNote",
                table: "TicketTechNote");

            migrationBuilder.RenameTable(
                name: "TicketTechNote",
                newName: "TicketTechNotes");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTechNote_TechNoteId",
                table: "TicketTechNotes",
                newName: "IX_TicketTechNotes_TechNoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTechNotes",
                table: "TicketTechNotes",
                columns: new[] { "TicketId", "TechNoteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechNotes_Notes_TechNoteId",
                table: "TicketTechNotes",
                column: "TechNoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechNotes_Tickets_TicketId",
                table: "TicketTechNotes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechNotes_Notes_TechNoteId",
                table: "TicketTechNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketTechNotes_Tickets_TicketId",
                table: "TicketTechNotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketTechNotes",
                table: "TicketTechNotes");

            migrationBuilder.RenameTable(
                name: "TicketTechNotes",
                newName: "TicketTechNote");

            migrationBuilder.RenameIndex(
                name: "IX_TicketTechNotes_TechNoteId",
                table: "TicketTechNote",
                newName: "IX_TicketTechNote_TechNoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketTechNote",
                table: "TicketTechNote",
                columns: new[] { "TicketId", "TechNoteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechNote_Notes_TechNoteId",
                table: "TicketTechNote",
                column: "TechNoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketTechNote_Tickets_TicketId",
                table: "TicketTechNote",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
