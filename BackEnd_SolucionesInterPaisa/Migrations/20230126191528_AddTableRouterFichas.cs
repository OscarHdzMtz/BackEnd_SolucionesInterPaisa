using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    public partial class AddTableRouterFichas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutersFichas",
                columns: table => new
                {
                    idMKT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccionIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nombreMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ordenMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoMKT = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutersFichas", x => x.idMKT);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutersFichas");
        }
    }
}
