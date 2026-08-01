using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CambiosAEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParadaId",
                table: "Ruta");

            migrationBuilder.AddColumn<int>(
                name: "RutaId",
                table: "Bus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Parada_RutaId",
                table: "Parada",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_RutaId",
                table: "Horario",
                column: "RutaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bus_RutaId",
                table: "Bus",
                column: "RutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Ruta_RutaId",
                table: "Bus",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Horario_Ruta_RutaId",
                table: "Horario",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parada_Ruta_RutaId",
                table: "Parada",
                column: "RutaId",
                principalTable: "Ruta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Ruta_RutaId",
                table: "Bus");

            migrationBuilder.DropForeignKey(
                name: "FK_Horario_Ruta_RutaId",
                table: "Horario");

            migrationBuilder.DropForeignKey(
                name: "FK_Parada_Ruta_RutaId",
                table: "Parada");

            migrationBuilder.DropIndex(
                name: "IX_Parada_RutaId",
                table: "Parada");

            migrationBuilder.DropIndex(
                name: "IX_Horario_RutaId",
                table: "Horario");

            migrationBuilder.DropIndex(
                name: "IX_Bus_RutaId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "RutaId",
                table: "Bus");

            migrationBuilder.AddColumn<int>(
                name: "ParadaId",
                table: "Ruta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
