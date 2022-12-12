using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonContactExtractor.Migrations
{
    /// <inheritdoc />
    public partial class RemoveDocumentResultEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DocumentResultEntity_DocumentResultId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DocumentResultEntity");

            migrationBuilder.DropIndex(
                name: "IX_Results_DocumentId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentResultId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentResultId",
                table: "Documents");

            migrationBuilder.CreateIndex(
                name: "IX_Results_DocumentId",
                table: "Results",
                column: "DocumentId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Results_DocumentId",
                table: "Results");

            migrationBuilder.AddColumn<int>(
                name: "DocumentResultId",
                table: "Documents",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentResultEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDateTimeUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DocumentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ResultId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentResultEntity", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Results_DocumentId",
                table: "Results",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentResultId",
                table: "Documents",
                column: "DocumentResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DocumentResultEntity_DocumentResultId",
                table: "Documents",
                column: "DocumentResultId",
                principalTable: "DocumentResultEntity",
                principalColumn: "Id");
        }
    }
}
