using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jedster.Plugins.EntityFrameworkCorePSQL.Migrations
{
    /// <inheritdoc />
    public partial class TGSCTLA4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textbooks_TextBookTypes_TextBookTypeId",
                table: "Textbooks");

            migrationBuilder.DropIndex(
                name: "IX_Textbooks_TextBookTypeId",
                table: "Textbooks");

            migrationBuilder.DropColumn(
                name: "TextBookTypeId",
                table: "Textbooks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextBookTypeId",
                table: "Textbooks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Textbooks_TextBookTypeId",
                table: "Textbooks",
                column: "TextBookTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Textbooks_TextBookTypes_TextBookTypeId",
                table: "Textbooks",
                column: "TextBookTypeId",
                principalTable: "TextBookTypes",
                principalColumn: "Id");
        }
    }
}
