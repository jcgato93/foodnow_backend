using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class RestaurantCategory
    {
        [Key]
        public int Id { get; set; }

        public int? RestaurantId { get; set; }

        public int? CategoryId { get; set; }

        // ===== Foraneas =========

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }
    }
}
