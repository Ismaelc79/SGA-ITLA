using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SGA.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionRelacionesEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Bus_ConductorId",
                table: "Bus",
                column: "ConductorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Conductor_ConductorId",
                table: "Bus",
                column: "ConductorId",
                principalTable: "Conductor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Conductor_ConductorId",
                table: "Bus");

            migrationBuilder.DropIndex(
                name: "IX_Bus_ConductorId",
                table: "Bus");
        }
    }
}
