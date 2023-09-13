using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlanesFichas",
                columns: table => new
                {
                    idProfile = table.Column<string>(type: "varchar(255)", nullable: false),
                    tipoDeFichas = table.Column<string>(type: "longtext", nullable: true),
                    nameProfile = table.Column<string>(type: "longtext", nullable: false),
                    addressPoolProfile = table.Column<string>(type: "longtext", nullable: true),
                    velocidadSubidaBajadaProfile = table.Column<string>(type: "longtext", nullable: true),
                    limiteDeTiempoProfile = table.Column<string>(type: "longtext", nullable: true),
                    addMacCookieProfile = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    onLoginProfile = table.Column<string>(type: "longtext", nullable: true),
                    onLogoutProfile = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanesFichas", x => x.idProfile);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoutersFichas",
                columns: table => new
                {
                    idMikrotik = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    idCliente = table.Column<int>(type: "int", nullable: false),
                    direccionIPMKT = table.Column<string>(type: "longtext", nullable: false),
                    usuarioIPMKT = table.Column<string>(type: "longtext", nullable: false),
                    passwordIPMKT = table.Column<string>(type: "longtext", nullable: true),
                    ordenMKT = table.Column<string>(type: "longtext", nullable: false),
                    estadoMKT = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Routerboard = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BoardName = table.Column<string>(type: "longtext", nullable: true),
                    Model = table.Column<string>(type: "longtext", nullable: true),
                    SerialNumber = table.Column<string>(type: "longtext", nullable: true),
                    FirmwareType = table.Column<string>(type: "longtext", nullable: true),
                    FactoryFirmware = table.Column<string>(type: "longtext", nullable: true),
                    CurrentFirmware = table.Column<string>(type: "longtext", nullable: true),
                    UpgradeFirmware = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutersFichas", x => x.idMikrotik);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsuariosCreadosHotspot",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false),
                    id_Cliente = table.Column<string>(type: "longtext", nullable: true),
                    id_Mikrotik = table.Column<string>(type: "longtext", nullable: true),
                    id_vendedor = table.Column<string>(type: "longtext", nullable: true),
                    address = table.Column<string>(type: "longtext", nullable: true),
                    bytesIn = table.Column<long>(type: "bigint", nullable: false),
                    bytesOut = table.Column<long>(type: "bigint", nullable: false),
                    comment = table.Column<string>(type: "longtext", nullable: true),
                    disabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: true),
                    limitBytesIn = table.Column<long>(type: "bigint", nullable: false),
                    limitBytesOut = table.Column<long>(type: "bigint", nullable: false),
                    limitBytesTotal = table.Column<int>(type: "int", nullable: false),
                    limitUptime = table.Column<string>(type: "longtext", nullable: true),
                    macAddress = table.Column<string>(type: "longtext", nullable: true),
                    name = table.Column<string>(type: "longtext", nullable: true),
                    packetsIn = table.Column<long>(type: "bigint", nullable: false),
                    packetsOut = table.Column<long>(type: "bigint", nullable: false),
                    password = table.Column<string>(type: "longtext", nullable: true),
                    profile = table.Column<string>(type: "longtext", nullable: true),
                    routes = table.Column<string>(type: "longtext", nullable: true),
                    server = table.Column<string>(type: "longtext", nullable: true),
                    uptime = table.Column<string>(type: "longtext", nullable: true),
                    cantidadfichas = table.Column<string>(type: "longtext", nullable: true),
                    vendedorFichas = table.Column<string>(type: "longtext", nullable: true),
                    servidorHotspot = table.Column<string>(type: "longtext", nullable: true),
                    planesFichas = table.Column<string>(type: "longtext", nullable: true),
                    prefijoFichas = table.Column<string>(type: "longtext", nullable: true),
                    LongitudUserFichas = table.Column<int>(type: "int", nullable: false),
                    tipoUsuarioGenerarFichas = table.Column<string>(type: "longtext", nullable: true),
                    tipoInicioDeSesionFichas = table.Column<string>(type: "longtext", nullable: true),
                    valorLongPassFichas = table.Column<int>(type: "int", nullable: false),
                    tipoPasswordGenerarFichas = table.Column<string>(type: "longtext", nullable: true),
                    fechaCreacion = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCreadosHotspot", x => x.id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanesFichas");

            migrationBuilder.DropTable(
                name: "RoutersFichas");

            migrationBuilder.DropTable(
                name: "UsuariosCreadosHotspot");
        }
    }
}
