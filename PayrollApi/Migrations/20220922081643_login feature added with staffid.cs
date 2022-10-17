using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class loginfeatureaddedwithstaffid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "Register2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StaffID",
                table: "Employeees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "StaffID",
                table: "Employeees");
        }
    }
}
