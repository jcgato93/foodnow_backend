using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class SaleDTO
    {
        
        public long Id { get; set; }

        [Required]
        public long OrderId { get; set; }

        public int ProductId { get; set; }

        // Precio del producto cuando se vendio
        [Required]
        public double CurrentPrice { get; set; }
    }
}
