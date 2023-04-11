using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class UsuariosCreadosHotspot
    {
        [Key]
        public string id { get; set; }
        public string id_Cliente { get; set; }
        public string id_Mikrotik { get; set; }
        public string id_vendedor { get; set; }
        public string address { get; set; }        
        public long bytesIn { get; set; }
        public long bytesOut { get; set; }
        public string comment { get; set; }
        public bool disabled { get; set; }
        public string email { get; set; }        
        public long limitBytesIn { get; set; }
        public long limitBytesOut { get; set; }
        public int limitBytesTotal { get; set; }
        public string limitUptime { get; set; }
        public string macAddress { get; set; }
        public string name { get; set; }
        public long packetsIn { get; set; }
        public long packetsOut { get; set; }
        public string password { get; set; }
        public string profile { get; set; }
        public string routes { get; set; }
        public string server { get; set; }
        public string uptime { get; set; }
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
        public string fechaCreacion { get; set; }
    }
}
