using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensino.Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DegreeFK",
                table: "MyUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "MyUser",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "MyUser",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentNumber",
                table: "MyUser",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TuitionFee",
                table: "MyUser",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DegreeFK",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "MyUser");

            migrationBuilder.DropColumn(
                name: "TuitionFee",
                table: "MyUser");
        }
    }
}
