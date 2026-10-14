using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase6.EF.Entidades.Migrations
{
    /// <inheritdoc />
    public partial class AgregandoTematica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TematicaId",
                table: "Juguetes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Tematica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tematica", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Juguetes_TematicaId",
                table: "Juguetes",
                column: "TematicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Juguetes_Tematica_TematicaId",
                table: "Juguetes",
                column: "TematicaId",
                principalTable: "Tematica",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Juguetes_Tematica_TematicaId",
                table: "Juguetes");

            migrationBuilder.DropTable(
                name: "Tematica");

            migrationBuilder.DropIndex(
                name: "IX_Juguetes_TematicaId",
                table: "Juguetes");

            migrationBuilder.DropColumn(
                name: "TematicaId",
                table: "Juguetes");
        }
    }
}
