using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangesToPersistenceEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Pagos",
                newName: "EstudianteId");

            migrationBuilder.AddColumn<int>(
                name: "PagoId",
                table: "TarjetasRecargables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PagoId",
                table: "TarjetasRecargables");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Pagos",
                newName: "UsuarioId");
        }
    }
}
