using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class TiposUsuarios
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        [Required]
        public string TipoUsuarios { get; set; }
    }
}
