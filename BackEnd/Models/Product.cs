using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }
        

        // ==== Foraneas ======
        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant restaurant { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public virtual Category category { get; set; }

    }
}
