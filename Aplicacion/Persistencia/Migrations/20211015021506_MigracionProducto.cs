using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class MigracionProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consolas");

            migrationBuilder.AddColumn<int>(
                name: "Almacenamiento",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Productos",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoAlmacenamiento",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VelocidadProcesador",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VelocidadRam",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "Productos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Almacenamiento",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "TipoAlmacenamiento",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VelocidadProcesador",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "VelocidadRam",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "Productos");

            migrationBuilder.CreateTable(
                name: "Consolas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Almacenamiento = table.Column<int>(type: "int", nullable: false),
                    Fabricante = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    TipoAlmacenamiento = table.Column<int>(type: "int", nullable: false),
                    VelocidadProcesador = table.Column<int>(type: "int", nullable: false),
                    VelocidadRam = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consolas", x => x.Id);
                });
        }
    }
}
