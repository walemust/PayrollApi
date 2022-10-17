using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class addedDOBandconfirmpassworddetailstotheEmployeeandRegisterViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Register2");

            migrationBuilder.AddColumn<string>(
                name: "ChangePassword",
                table: "Register2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Register2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Employeees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Employeees");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Register2",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
