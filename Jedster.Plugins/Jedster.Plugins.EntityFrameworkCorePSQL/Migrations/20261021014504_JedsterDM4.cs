using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jedster.Plugins.EntityFrameworkCorePSQL.Migrations
{
    /// <inheritdoc />
    public partial class JedsterDM4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Students_StudentInfoStudentId",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_StudentInfoStudentId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "StudentInfoStudentId",
                table: "Attendances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentInfoStudentId",
                table: "Attendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_StudentInfoStudentId",
                table: "Attendances",
                column: "StudentInfoStudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Students_StudentInfoStudentId",
                table: "Attendances",
                column: "StudentInfoStudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
