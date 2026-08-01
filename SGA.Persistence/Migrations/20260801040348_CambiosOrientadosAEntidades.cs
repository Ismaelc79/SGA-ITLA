using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambiosOrientadosAEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_AutobusId",
                table: "Viaje",
                column: "AutobusId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_ConductorId",
                table: "Viaje",
                column: "ConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_HorarioId",
                table: "Viaje",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_IncidenciaId",
                table: "Viaje",
                column: "IncidenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Viaje_RutaId",
                table: "Viaje",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_EstudianteId",
                table: "Ticket",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_PagoId",
                table: "Ticket",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ParadaId",
                table: "Ticket",
                column: "ParadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_RutaId",
                table: "Ticket",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaRecargable_EstudianteId",
                table: "TarjetaRecargable",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaRecargable_PagoId",
                table: "TarjetaRecargable",
                column: "PagoId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAcceso_AutorizacionId",
                table: "RegistroAcceso",
                column: "AutorizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAcceso_UsuarioId",
                table: "RegistroAcceso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroAcceso_ViajeId",
                table: "RegistroAcceso",
                column: "ViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pago_EstudianteId",
                table: "Pago",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_UsuarioId",
                table: "Estudiante",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_UsuarioId",
                table: "Empleado",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Conductor_UsuarioId",
                table: "Conductor",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Autorizacion_UsuarioId",
                table: "Autorizacion",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Autorizacion_Usuario_UsuarioId",
                table: "Autorizacion",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Conductor_Usuario_UsuarioId",
                table: "Conductor",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Empleado_Usuario_UsuarioId",
                table: "Empleado",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Usuario_UsuarioId",
                table: "Estudiante",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notificaciones_Usuario_UsuarioId",
                table: "Notificaciones",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pago_Estudiante_EstudianteId",
                table: "Pago",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroAcceso_Autorizacion_AutorizacionId",
                table: "RegistroAcceso",
                column: "AutorizacionId",
                principalTable: "Autorizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroAcceso_Usuario_UsuarioId",
                table: "RegistroAcceso",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroAcceso_Viaje_ViajeId",
                table: "RegistroAcceso",
                column: "ViajeId",
                principalTable: "Viaje",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaRecargable_Estudiante_EstudianteId",
                table: "TarjetaRecargable",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaRecargable_Pago_PagoId",
                table: "TarjetaRecargable",
                column: "PagoId",
                principalTable: "Pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Estudiante_EstudianteId",
                table: "Ticket",
                column: "EstudianteId",
                principalTable: "Estudiante",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Pago_PagoId",
                table: "Ticket",
                column: "PagoId",
                principalTable: "Pago",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Parada_ParadaId",
                table: "Ticket",
                column: "ParadaId",
                principalTable: "Parada",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Ruta_RutaId",
                table: "Ticket",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Bus_AutobusId",
                table: "Viaje",
                column: "AutobusId",
                principalTable: "Bus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Conductor_ConductorId",
                table: "Viaje",
                column: "ConductorId",
                principalTable: "Conductor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Horario_HorarioId",
                table: "Viaje",
                column: "HorarioId",
                principalTable: "Horario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Incidencia_IncidenciaId",
                table: "Viaje",
                column: "IncidenciaId",
                principalTable: "Incidencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viaje_Ruta_RutaId",
                table: "Viaje",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Autorizacion_Usuario_UsuarioId",
                table: "Autorizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Conductor_Usuario_UsuarioId",
                table: "Conductor");

            migrationBuilder.DropForeignKey(
                name: "FK_Empleado_Usuario_UsuarioId",
                table: "Empleado");

            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Usuario_UsuarioId",
                table: "Estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_Notificaciones_Usuario_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Pago_Estudiante_EstudianteId",
                table: "Pago");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroAcceso_Autorizacion_AutorizacionId",
                table: "RegistroAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroAcceso_Usuario_UsuarioId",
                table: "RegistroAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroAcceso_Viaje_ViajeId",
                table: "RegistroAcceso");

            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaRecargable_Estudiante_EstudianteId",
                table: "TarjetaRecargable");

            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaRecargable_Pago_PagoId",
                table: "TarjetaRecargable");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Estudiante_EstudianteId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Pago_PagoId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Parada_ParadaId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Ruta_RutaId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Bus_AutobusId",
                table: "Viaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Conductor_ConductorId",
                table: "Viaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Horario_HorarioId",
                table: "Viaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Incidencia_IncidenciaId",
                table: "Viaje");

            migrationBuilder.DropForeignKey(
                name: "FK_Viaje_Ruta_RutaId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_AutobusId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_ConductorId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_HorarioId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_IncidenciaId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Viaje_RutaId",
                table: "Viaje");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_EstudianteId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_PagoId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ParadaId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_RutaId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_TarjetaRecargable_EstudianteId",
                table: "TarjetaRecargable");

            migrationBuilder.DropIndex(
                name: "IX_TarjetaRecargable_PagoId",
                table: "TarjetaRecargable");

            migrationBuilder.DropIndex(
                name: "IX_RegistroAcceso_AutorizacionId",
                table: "RegistroAcceso");

            migrationBuilder.DropIndex(
                name: "IX_RegistroAcceso_UsuarioId",
                table: "RegistroAcceso");

            migrationBuilder.DropIndex(
                name: "IX_RegistroAcceso_ViajeId",
                table: "RegistroAcceso");

            migrationBuilder.DropIndex(
                name: "IX_Pago_EstudianteId",
                table: "Pago");

            migrationBuilder.DropIndex(
                name: "IX_Notificaciones_UsuarioId",
                table: "Notificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_UsuarioId",
                table: "Estudiante");

            migrationBuilder.DropIndex(
                name: "IX_Empleado_UsuarioId",
                table: "Empleado");

            migrationBuilder.DropIndex(
                name: "IX_Conductor_UsuarioId",
                table: "Conductor");

            migrationBuilder.DropIndex(
                name: "IX_Autorizacion_UsuarioId",
                table: "Autorizacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Rol_RolId",
                table: "Usuario",
                column: "RolId",
                principalTable: "Rol",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
