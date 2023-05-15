using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentInformationSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Enrollments",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Enrollments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "ID");
        }
    }
}
