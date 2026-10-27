using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jedster.Plugins.EntityFrameworkCorePSQL.Migrations
{
    /// <inheritdoc />
    public partial class JedsterDM5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Attendances",
                newName: "AttendanceStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AttendanceStatus",
                table: "Attendances",
                newName: "Status");
        }
    }
}
