using Microsoft.EntityFrameworkCore.Migrations;

namespace Sa.Repository.Migrations
{
    public partial class StudentEntityChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AssignedProfessor",
                table: "Students",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedProfessor",
                table: "Students");

            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
