using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class RestaurantCategoryDTO
    {
        
        public int Id { get; set; }

        [Required]
        public int RestaurantId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
