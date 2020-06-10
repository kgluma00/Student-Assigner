using Microsoft.EntityFrameworkCore.Migrations;

namespace Sa.Repository.Migrations
{
    public partial class StudentEntityChangedFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedProfessor",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AssignedProfessor",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
