using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewChangesToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViajeId",
                table: "Incidencia");

            migrationBuilder.AddColumn<int>(
                name: "IndicenciaId",
                table: "Viaje",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IndicenciaId",
                table: "Viaje");

            migrationBuilder.AddColumn<int>(
                name: "ViajeId",
                table: "Incidencia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
