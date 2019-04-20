using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class RestaurantDTO
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }


        public  ICollection<ProductDTO> Products { get; set; }
        public  ICollection<BranchDTO> Branches { get; set; }
    }
}
