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
        public int id { get; set; }
        [Required]
        public string direccionIPMKT { get; set; }
        [Required]
        public string usuarioIPMKT { get; set; }
        [Required]
        public string passwordIPMKT { get; set; }
        [Required]
        public string nombreMKT { get; set; }
    }
}
