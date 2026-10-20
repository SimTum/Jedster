using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jedster.Plugins.EntityFrameworkCorePSQL.Migrations
{
    /// <inheritdoc />
    public partial class JedsterDM2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lessons_LessonId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LessonId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TeacherId",
                table: "Attendances",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentLesson",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "integer", nullable: false),
                    StudentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLesson", x => new { x.LessonId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_StudentLesson_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLesson_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_TeacherId",
                table: "Attendances",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLesson_StudentId",
                table: "StudentLesson",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_Teachers_TeacherId",
                table: "Attendances",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "TeacherId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_Teachers_TeacherId",
                table: "Attendances");

            migrationBuilder.DropTable(
                name: "StudentLesson");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_TeacherId",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "Attendances");

            migrationBuilder.AddColumn<int>(
                name: "LessonId",
                table: "Students",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LessonId",
                table: "Students",
                column: "LessonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lessons_LessonId",
                table: "Students",
                column: "LessonId",
                principalTable: "Lessons",
                principalColumn: "LessonId");
        }
    }
}
