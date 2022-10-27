using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    public partial class ActualizarRoutersMikrotik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "RoutersFichas",
                newName: "idMKT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "idMKT",
                table: "RoutersFichas",
                newName: "id");
        }
    }
}
