using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Productos
    {
        [Key]
        public int IdProducto { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string PLU { get; set; }
        [Required]
        public int IdCategoria { get; set; }
        [Required]
        public int IdStock { get; set; }
        [Required]
        public double Precio { get; set; }
    }
}
