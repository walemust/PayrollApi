using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class changednametofullname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Register2");

            migrationBuilder.AddColumn<string>(
                name: "Fullname",
                table: "Register2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fullname",
                table: "Register2");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Register2",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
