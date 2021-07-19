using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class TiposPedidos
    {
        [Key]
        public int IdTipoPedido { get; set; }
        [Required]
        public string TiposPedido { get; set; }
    }
}
