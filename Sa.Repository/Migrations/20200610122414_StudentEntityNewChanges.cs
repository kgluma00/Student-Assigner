using Microsoft.EntityFrameworkCore.Migrations;

namespace Sa.Repository.Migrations
{
    public partial class StudentEntityNewChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
