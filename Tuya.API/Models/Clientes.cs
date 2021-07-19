using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Clientes
    {
        [Key]
        [Required]
        public string IdCliente { get; set; }
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
        public string Contacto2 { get; set; }
        [Required]
        public string Ciudad { get; set; }
    }
}
