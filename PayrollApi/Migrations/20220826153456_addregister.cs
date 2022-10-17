using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class addregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employeees",
                table: "Employeees");

            migrationBuilder.RenameTable(
                name: "Employeees",
                newName: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employeees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employeees",
                table: "Employeees",
                column: "Id");
        }
    }
}
