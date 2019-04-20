using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
