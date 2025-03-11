using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageConnections",
                columns: table => new
                {
                    MessageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderID = table.Column<int>(type: "int", nullable: true),
                    RecieverID = table.Column<int>(type: "int", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MessageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageConnections", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_MessageConnections_Writers_RecieverID",
                        column: x => x.RecieverID,
                        principalTable: "Writers",
                        principalColumn: "WriteID");
                    table.ForeignKey(
                        name: "FK_MessageConnections_Writers_SenderID",
                        column: x => x.SenderID,
                        principalTable: "Writers",
                        principalColumn: "WriteID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageConnections_RecieverID",
                table: "MessageConnections",
                column: "RecieverID");

            migrationBuilder.CreateIndex(
                name: "IX_MessageConnections_SenderID",
                table: "MessageConnections",
                column: "SenderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageConnections");
        }
    }
}
