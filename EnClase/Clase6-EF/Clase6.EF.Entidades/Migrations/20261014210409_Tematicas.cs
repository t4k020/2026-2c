using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase6.EF.Entidades.Migrations
{
    /// <inheritdoc />
    public partial class Tematicas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tematicas_Libros_LibroId",
                table: "Tematicas");

            migrationBuilder.DropIndex(
                name: "IX_Tematicas_LibroId",
                table: "Tematicas");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Tematicas");

            migrationBuilder.CreateTable(
                name: "TematicasLibro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TematicasLibro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibroTematicaLibro",
                columns: table => new
                {
                    LibrosId = table.Column<int>(type: "int", nullable: false),
                    TematicasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroTematicaLibro", x => new { x.LibrosId, x.TematicasId });
                    table.ForeignKey(
                        name: "FK_LibroTematicaLibro_Libros_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroTematicaLibro_TematicasLibro_TematicasId",
                        column: x => x.TematicasId,
                        principalTable: "TematicasLibro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibroTematicaLibro_TematicasId",
                table: "LibroTematicaLibro",
                column: "TematicasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroTematicaLibro");

            migrationBuilder.DropTable(
                name: "TematicasLibro");

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Tematicas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tematicas_LibroId",
                table: "Tematicas",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tematicas_Libros_LibroId",
                table: "Tematicas",
                column: "LibroId",
                principalTable: "Libros",
                principalColumn: "Id");
        }
    }
}
