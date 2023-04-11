using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class UsuarioFichas
    {
        [Key]
        public int id { get; set; }
        public string idMikrotik { get; set; }
        public string cantidadfichas { get; set; }
        public string vendedorFichas { get; set; }
        public string servidorHotspot { get; set; }
        public string planesFichas { get; set; }
        public string prefijoFichas { get; set; }
        public int LongitudUserFichas { get; set; }
        public string tipoUsuarioGenerarFichas { get; set; }
        public string tipoInicioDeSesionFichas { get; set; }
        public int valorLongPassFichas { get; set; }
        public string tipoPasswordGenerarFichas { get; set; }

    }
}
