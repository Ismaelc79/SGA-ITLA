using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToEntitiesMatchingCorrectValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HoraInicio",
                table: "Horarios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "HoraFin",
                table: "Horarios",
                type: "time",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraInicio",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraFin",
                table: "Horarios",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");
        }
    }
}
