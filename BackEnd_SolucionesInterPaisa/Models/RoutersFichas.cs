using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_SolucionesInterPaisa.Models
{
    public class RoutersFichas
    {
        [Key]
        public int idMKT { get; set; }
        [Required]
        public string direccionIPMKT { get; set; }
        [Required]
        public string usuarioIPMKT { get; set; }
        
        public string passwordIPMKT { get; set; }
        [Required]
        public string nombreMKT { get; set; }
        [Required]
        public string ordenMKT { get; set; }        
        public bool estadoMKT { get; set; }
    }
}
