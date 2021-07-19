using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Facturas
    {
        [Key]
        public int IdFactura { get; set; }
        [Required]
        public string IdCliente { get; set; }
        [Required]
        public int IdDetalleFactura { get; set; }
        [Required]
        public double SubTotal { get; set; }
        [Required]
        public double Impuestos { get; set; }
        [Required]
        public double Flete { get; set; }
        [Required]
        public double Total { get; set; }
        [Required]
        public DateTime FechaFactura { get; set; }
        [Required]
        public int UsuarioFactura { get; set; }
    }
}
