using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clase6.EF.Entidades.Migrations
{
    /// <inheritdoc />
    public partial class Agregandosucursales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sucursales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JugueteSucursal",
                columns: table => new
                {
                    JuguetesId = table.Column<int>(type: "int", nullable: false),
                    SucursalesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JugueteSucursal", x => new { x.JuguetesId, x.SucursalesId });
                    table.ForeignKey(
                        name: "FK_JugueteSucursal_Juguetes_JuguetesId",
                        column: x => x.JuguetesId,
                        principalTable: "Juguetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JugueteSucursal_Sucursales_SucursalesId",
                        column: x => x.SucursalesId,
                        principalTable: "Sucursales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JugueteSucursal_SucursalesId",
                table: "JugueteSucursal",
                column: "SucursalesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JugueteSucursal");

            migrationBuilder.DropTable(
                name: "Sucursales");
        }
    }
}
