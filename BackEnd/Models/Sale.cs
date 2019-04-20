using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Sale
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }


        // Precio del producto cuando se vendio
        [Required]
        public double CurrentPrice { get; set; }



        // ====== Foraneas ============
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
    }
}
