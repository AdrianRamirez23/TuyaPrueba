using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Categorias
    {
        [Key]
        public int IdCategoria { get; set; }
        [Required]
        public string DescripcionCategoria { get; set; }
    }
}
