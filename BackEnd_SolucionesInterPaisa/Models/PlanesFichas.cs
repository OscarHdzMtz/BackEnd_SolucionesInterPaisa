using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class PlanesFichas
    {
        public string idProfile { get; set; }
        [Required]
        public string nameProfile { get; set; }
        public string addressPoolProfile { get; set; }
        //rateLimit
        public string velocidadSubidaBajadaProfile { get; set; }
        //macCookieTimeout
        public string limiteDeTiempoProfile { get; set; }
        public bool addMacCookieProfile { get; set; }
        public string onLoginProfile { get; set; }
        public string onLogoutProfile { get; set; }


        //public string precioFicha { get; set; }
        //public string modoExpirado { get; set; }
            
        //public string fichaExpiraEn { get; set; }
        //public string desconectarEn { get; set; }
    }
}

