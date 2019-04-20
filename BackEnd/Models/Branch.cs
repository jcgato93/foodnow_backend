using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    // Sucursal
    public class Branch
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int RestaurantId { get; set; }


        public virtual ICollection<Order> Orders { get; set; }


        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurant Restaurant { get; set; }
    }
}
