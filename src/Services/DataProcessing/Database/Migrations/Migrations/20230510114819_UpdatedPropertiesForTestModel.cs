using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPropertiesForTestModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "LogsProcessed",
                newName: "Timestamp");

            migrationBuilder.AddColumn<bool>(
                name: "Error",
                table: "LogsProcessed",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ExceptionType",
                table: "LogsProcessed",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FaultyCodePlacement",
                table: "LogsProcessed",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogMessage",
                table: "LogsProcessed",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Warning",
                table: "LogsProcessed",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Error",
                table: "LogsProcessed");

            migrationBuilder.DropColumn(
                name: "ExceptionType",
                table: "LogsProcessed");

            migrationBuilder.DropColumn(
                name: "FaultyCodePlacement",
                table: "LogsProcessed");

            migrationBuilder.DropColumn(
                name: "LogMessage",
                table: "LogsProcessed");

            migrationBuilder.DropColumn(
                name: "Warning",
                table: "LogsProcessed");

            migrationBuilder.RenameColumn(
                name: "Timestamp",
                table: "LogsProcessed",
                newName: "Content");
        }
    }
}
