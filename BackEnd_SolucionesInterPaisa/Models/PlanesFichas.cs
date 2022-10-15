using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class PlanesFichas
    {
        public int id { get; set; }
        public string nombrePerfil { get; set; }
        public double velocidadSubida { get; set; }
        public double velocidadbajada { get; set; }
        public string precioFicha { get; set; }
        public string tipoCorrido { get; set; }
        public string limiteDeTiempo { get; set; }
        public string fichaExpiraEn { get; set; }
        public string desconectarEn { get; set; }
    }
}
