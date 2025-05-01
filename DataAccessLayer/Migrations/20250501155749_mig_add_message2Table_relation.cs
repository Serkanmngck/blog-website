using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_message2Table_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Message2s",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sender = table.Column<int>(type: "int", nullable: true),
                    Receiver = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message2s", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_Receiver",
                        column: x => x.Receiver,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                    table.ForeignKey(
                        name: "FK_Message2s_Writers_Sender",
                        column: x => x.Sender,
                        principalTable: "Writers",
                        principalColumn: "WriterID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_Receiver",
                table: "Message2s",
                column: "Receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_Sender",
                table: "Message2s",
                column: "Sender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message2s");
        }
    }
}
