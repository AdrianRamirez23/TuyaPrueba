using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string CorreoElectronico { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Contacto1 { get; set; }
        [Required]
        public string Contacto2 { get; set; }
        [Required]
        public int IdTipoUsuario { get; set; }
        [Required]
        public string Ciudad { get; set; }
    }
}
