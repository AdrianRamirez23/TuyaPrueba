using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Pedidos
    {
        [Key]
        public int IdPedido { get; set; }
        [Required]
        public int IdTipoPedido { get; set; }
        [Required]
        public int IdFactura { get; set; }
        [Required]
        public int IdDetalleFactura { get; set; }
        public DateTime FechaDespacho { get; set; }
        public DateTime? FechaReparto { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
