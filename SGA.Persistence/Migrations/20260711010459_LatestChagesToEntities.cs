using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class LatestChagesToEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tickets",
                newName: "EstudianteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Tickets",
                newName: "UsuarioId");
        }
    }
}
