using BackEnd_SolucionesInterPaisa.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.data
{
    //innstalamos Microsoft.EntityFrameworkCore para que reconosca el DbContext
    //instalamos Microsoft.EntityFrameworkCore.tools para poder utilizar el app-migration y el update-database
    //instalamos Microsoft.EntityFrameworkCore.SqlServer para poder hacer conexion a la base de datos
    public class ApplicationDbContext : DbContext
    {

        //Crear Constructor para que tome la cadena de conexion y empiece a generar las tablas
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base (option)
        {

        }
        //AGREGAR LOS MODELOS QUE SE VAN A CONVERTIR EN TABLAS
        public DbSet<RoutersFichas> RoutersFichas { get; set; }
        public DbSet<UsuariosCreadosHotspot> UsuariosCreadosHotspot { get; set; }        

    }
}
