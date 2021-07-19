using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class DetalleFactura
    {
        [Key]
        public int IdDetail { get; set; }
        [Required]
        public int IdDetalleFactura { get; set; }
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
