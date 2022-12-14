// <auto-generated />
using BackEnd_SolucionesInterPaisa.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd_SolucionesInterPaisa.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221020194811_ActualizarRoutersMikrotik")]
    partial class ActualizarRoutersMikrotik
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd_SolucionesInterPaisa.Models.RoutersFichas", b =>
                {
                    b.Property<int>("idMKT")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("direccionIPMKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombreMKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passwordIPMKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("usuarioIPMKT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idMKT");

                    b.ToTable("RoutersFichas");
                });
#pragma warning restore 612, 618
        }
    }
}
