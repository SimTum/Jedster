using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Jedster.Plugins.EntityFrameworkCorePSQL.Migrations
{
    /// <inheritdoc />
    public partial class TGSCTLA2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textbooks_TextbookData_TextbookTypeId",
                table: "Textbooks");

            migrationBuilder.DropTable(
                name: "TextbookData");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Contracts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "TextBookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HoursRecommended = table.Column<double>(type: "double precision", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBookTypes", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Textbooks_TextBookTypes_TextbookTypeId",
                table: "Textbooks",
                column: "TextbookTypeId",
                principalTable: "TextBookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Textbooks_TextBookTypes_TextbookTypeId",
                table: "Textbooks");

            migrationBuilder.DropTable(
                name: "TextBookTypes");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Contracts");

            migrationBuilder.CreateTable(
                name: "TextbookData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    HoursRecommended = table.Column<double>(type: "double precision", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextbookData", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Textbooks_TextbookData_TextbookTypeId",
                table: "Textbooks",
                column: "TextbookTypeId",
                principalTable: "TextbookData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
