using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Final_Web_Carlos.Migrations
{
    /// <inheritdoc />
    public partial class CambiarDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Motivos_MotivoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId",
                principalTable: "Consultorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Motivos_MotivoId",
                table: "Citas",
                column: "MotivoId",
                principalTable: "Motivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Motivos_MotivoId",
                table: "Citas");

            migrationBuilder.DropForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas");

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Consultorios_ConsultorioId",
                table: "Citas",
                column: "ConsultorioId",
                principalTable: "Consultorios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Motivos_MotivoId",
                table: "Citas",
                column: "MotivoId",
                principalTable: "Motivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Citas_Servicios_ServicioId",
                table: "Citas",
                column: "ServicioId",
                principalTable: "Servicios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
