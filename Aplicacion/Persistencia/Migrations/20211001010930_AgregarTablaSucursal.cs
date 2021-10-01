using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class AgregarTablaSucursal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_SucursalId",
                table: "Empleados",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Sucursal_SucursalId",
                table: "Empleados",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Sucursal_SucursalId",
                table: "Empleados");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_SucursalId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Empleados");
        }
    }
}
