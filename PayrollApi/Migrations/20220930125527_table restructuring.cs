using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PayrollApi.Migrations
{
    public partial class tablerestructuring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Register2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Register2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Register2",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Register2",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Register2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ChangePassword",
                table: "Employeees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Employeees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "Employeees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Employeees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employeees",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Employeees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Employeees",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Register2");

            migrationBuilder.DropColumn(
                name: "ChangePassword",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employeees");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Employeees");
        }
    }
}
