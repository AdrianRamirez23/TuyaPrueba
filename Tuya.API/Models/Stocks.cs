using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tuya.API.Models
{
    public class Stocks
    {
        [Key]
        public int IdStock { get; set; }
        [Required]
        public int StockCEDI { get; set; }
        [Required]
        public int StockVMI { get; set; }
        [Required]
        public int StockMKP { get; set; }
        [Required]
        public int StockTienda { get; set; }
    }
}
