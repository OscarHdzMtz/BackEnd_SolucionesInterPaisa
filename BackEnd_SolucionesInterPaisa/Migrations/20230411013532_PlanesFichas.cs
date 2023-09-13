using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    public partial class PlanesFichas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanesFichas",
                columns: table => new
                {
                    idProfile = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    tipoDeFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nameProfile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addressPoolProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    velocidadSubidaBajadaProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limiteDeTiempoProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    addMacCookieProfile = table.Column<bool>(type: "bit", nullable: false),
                    onLoginProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    onLogoutProfile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesFichas", x => x.idProfile);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanesFichas");
        }
    }
}
