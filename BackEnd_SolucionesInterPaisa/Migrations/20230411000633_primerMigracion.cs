using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    public partial class primerMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RoutersFichas",
                columns: table => new
                {
                    idMikrotik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    direccionIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuarioIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    passwordIPMKT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ordenMKT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estadoMKT = table.Column<bool>(type: "bit", nullable: false),
                    Routerboard = table.Column<bool>(type: "bit", nullable: false),
                    BoardName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirmwareType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryFirmware = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentFirmware = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpgradeFirmware = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutersFichas", x => x.idMikrotik);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCreadosHotspot",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_Mikrotik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_vendedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bytesIn = table.Column<long>(type: "bigint", nullable: false),
                    bytesOut = table.Column<long>(type: "bigint", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    disabled = table.Column<bool>(type: "bit", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    limitBytesIn = table.Column<long>(type: "bigint", nullable: false),
                    limitBytesOut = table.Column<long>(type: "bigint", nullable: false),
                    limitBytesTotal = table.Column<int>(type: "int", nullable: false),
                    limitUptime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    macAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    packetsIn = table.Column<long>(type: "bigint", nullable: false),
                    packetsOut = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    routes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    server = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uptime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidadfichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vendedorFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    servidorHotspot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    planesFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    prefijoFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongitudUserFichas = table.Column<int>(type: "int", nullable: false),
                    tipoUsuarioGenerarFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tipoInicioDeSesionFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valorLongPassFichas = table.Column<int>(type: "int", nullable: false),
                    tipoPasswordGenerarFichas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fechaCreacion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCreadosHotspot", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutersFichas");

            migrationBuilder.DropTable(
                name: "UsuariosCreadosHotspot");
        }
    }
}
