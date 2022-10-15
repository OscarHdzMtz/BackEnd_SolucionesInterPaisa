using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class Fichas
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public double precio { get; set; }
        public PlanesFichas idPerfilFichas { get; set; }
    }
}
