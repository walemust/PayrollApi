using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class updatedthedetailsintheEmployeeandRegisterViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Register2",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Phone",
                table: "Register2",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Salary",
                table: "Register2",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employeees",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employeees");
        }
    }
}
