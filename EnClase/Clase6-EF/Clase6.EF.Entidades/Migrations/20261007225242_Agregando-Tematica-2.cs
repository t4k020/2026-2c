using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase6.EF.Entidades.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoTematica2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juguetes_Tematica_TematicaId",
                table: "Juguetes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tematica",
                table: "Tematica");

            migrationBuilder.RenameTable(
                name: "Tematica",
                newName: "Tematicas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tematicas",
                table: "Tematicas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Juguetes_Tematicas_TematicaId",
                table: "Juguetes",
                column: "TematicaId",
                principalTable: "Tematicas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juguetes_Tematicas_TematicaId",
                table: "Juguetes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tematicas",
                table: "Tematicas");

            migrationBuilder.RenameTable(
                name: "Tematicas",
                newName: "Tematica");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tematica",
                table: "Tematica",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Juguetes_Tematica_TematicaId",
                table: "Juguetes",
                column: "TematicaId",
                principalTable: "Tematica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
