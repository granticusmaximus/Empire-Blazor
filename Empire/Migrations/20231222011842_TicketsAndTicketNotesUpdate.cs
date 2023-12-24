using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Empire.Migrations
{
    public partial class TicketsAndTicketNotesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Notes_Id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Notes_TicketId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TechNoteId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Notes");

            migrationBuilder.CreateTable(
                name: "TicketTechNote",
                columns: table => new
                {
                    TicketId = table.Column<string>(type: "TEXT", nullable: false),
                    TechNoteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketTechNote", x => new { x.TicketId, x.TechNoteId });
                    table.ForeignKey(
                        name: "FK_TicketTechNote_Notes_TechNoteId",
                        column: x => x.TechNoteId,
                        principalTable: "Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TicketTechNote_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "TicketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TicketTechNote_TechNoteId",
                table: "TicketTechNote",
                column: "TechNoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketTechNote");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TechNoteId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TicketId",
                table: "Notes",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Id",
                table: "Tickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_TicketId",
                table: "Notes",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Tickets_TicketId",
                table: "Notes",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Notes_Id",
                table: "Tickets",
                column: "Id",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
