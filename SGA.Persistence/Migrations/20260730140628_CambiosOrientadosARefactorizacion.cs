using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambiosOrientadosARefactorizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarjetasRecargables",
                table: "TarjetasRecargables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rutas",
                table: "Rutas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistrosAccesos",
                table: "RegistrosAccesos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paradas",
                table: "Paradas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conductores",
                table: "Conductores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buses",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "FechaCierre",
                table: "Notificaciones");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "TarjetasRecargables",
                newName: "TarjetaRecargable");

            migrationBuilder.RenameTable(
                name: "Rutas",
                newName: "Ruta");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Rol");

            migrationBuilder.RenameTable(
                name: "RegistrosAccesos",
                newName: "RegistroAcceso");

            migrationBuilder.RenameTable(
                name: "Paradas",
                newName: "Parada");

            migrationBuilder.RenameTable(
                name: "Pagos",
                newName: "Pago");

            migrationBuilder.RenameTable(
                name: "Horarios",
                newName: "Horario");

            migrationBuilder.RenameTable(
                name: "Estudiantes",
                newName: "Estudiante");

            migrationBuilder.RenameTable(
                name: "Empleados",
                newName: "Empleadp");

            migrationBuilder.RenameTable(
                name: "Conductores",
                newName: "Conductor");

            migrationBuilder.RenameTable(
                name: "Buses",
                newName: "Bus");

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

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuario",
                newName: "IX_Usuario_RolId");

            migrationBuilder.AddColumn<int>(
                name: "TipoNotificacion",
                table: "Notificaciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarjetaRecargable",
                table: "TarjetaRecargable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ruta",
                table: "Ruta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rol",
                table: "Rol",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistroAcceso",
                table: "RegistroAcceso",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parada",
                table: "Parada",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pago",
                table: "Pago",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horario",
                table: "Horario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiante",
                table: "Estudiante",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleadp",
                table: "Empleadp",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conductor",
                table: "Conductor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bus",
                table: "Bus",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Autorizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoAutorizacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autorizacion", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Autorizacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarjetaRecargable",
                table: "TarjetaRecargable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ruta",
                table: "Ruta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rol",
                table: "Rol");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RegistroAcceso",
                table: "RegistroAcceso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Parada",
                table: "Parada");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pago",
                table: "Pago");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Horario",
                table: "Horario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estudiante",
                table: "Estudiante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Empleadp",
                table: "Empleadp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Conductor",
                table: "Conductor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bus",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "TipoNotificacion",
                table: "Notificaciones");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Tickets");

            migrationBuilder.RenameTable(
                name: "TarjetaRecargable",
                newName: "TarjetasRecargables");

            migrationBuilder.RenameTable(
                name: "Ruta",
                newName: "Rutas");

            migrationBuilder.RenameTable(
                name: "Rol",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "RegistroAcceso",
                newName: "RegistrosAccesos");

            migrationBuilder.RenameTable(
                name: "Parada",
                newName: "Paradas");

            migrationBuilder.RenameTable(
                name: "Pago",
                newName: "Pagos");

            migrationBuilder.RenameTable(
                name: "Horario",
                newName: "Horarios");

            migrationBuilder.RenameTable(
                name: "Estudiante",
                newName: "Estudiantes");

            migrationBuilder.RenameTable(
                name: "Empleadp",
                newName: "Empleados");

            migrationBuilder.RenameTable(
                name: "Conductor",
                newName: "Conductores");

            migrationBuilder.RenameTable(
                name: "Bus",
                newName: "Buses");

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

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_RolId",
                table: "Usuarios",
                newName: "IX_Usuarios_RolId");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCierre",
                table: "Notificaciones",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarjetasRecargables",
                table: "TarjetasRecargables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rutas",
                table: "Rutas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RegistrosAccesos",
                table: "RegistrosAccesos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paradas",
                table: "Paradas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pagos",
                table: "Pagos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Horarios",
                table: "Horarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estudiantes",
                table: "Estudiantes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Empleados",
                table: "Empleados",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Conductores",
                table: "Conductores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buses",
                table: "Buses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Roles_RolId",
                table: "Usuarios",
                column: "RolId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
