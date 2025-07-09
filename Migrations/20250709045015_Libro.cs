using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Libros.Migrations
{
    /// <inheritdoc />
    public partial class Libro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LibreriasMaterial",
                columns: table => new
                {
                    LibreriaMaterialId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Titulo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaPublicacion = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AutoLibro = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    NewData = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibreriasMaterial", x => x.LibreriaMaterialId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibreriasMaterial");
        }
    }
}
