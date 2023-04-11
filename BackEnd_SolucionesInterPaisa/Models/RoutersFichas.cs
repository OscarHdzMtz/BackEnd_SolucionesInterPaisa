using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class RoutersFichas
    {        
        public int idCliente { get; set; }
        [Key]
        public int idMikrotik { get; set; }
        [Required]
        public string direccionIPMKT { get; set; }
        [Required]
        public string usuarioIPMKT { get; set; }        
        public string passwordIPMKT { get; set; }                
        [Required]
        public string ordenMKT { get; set; }        
        public bool estadoMKT { get; set; }
		public bool Routerboard { get; set; }	
		public string BoardName { get; set; }
		public string Model { get; set; }
		public string SerialNumber { get; set; }
		public string FirmwareType { get; set; }
		public string FactoryFirmware { get; set; }
		public string CurrentFirmware { get; set; }
		public string UpgradeFirmware { get; set; }
	}
}
