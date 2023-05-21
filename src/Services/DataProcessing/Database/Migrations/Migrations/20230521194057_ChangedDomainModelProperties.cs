using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrations.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDomainModelProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
