using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCierre",
                table: "Notificaciones");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Notificaciones",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Notificaciones",
                newName: "FechaHora");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "Notificaciones",
                newName: "Descripcion");

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificacion",
                table: "Notificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoNotificacion",
                table: "Notificaciones");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Notificaciones",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "FechaHora",
                table: "Notificaciones",
                newName: "FechaInicio");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Notificaciones",
                newName: "Estado");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCierre",
                table: "Notificaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
