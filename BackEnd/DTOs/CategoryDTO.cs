using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class CategoryDTO
    {        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        public ICollection<ProductDTO> Products { get; set; }
    }
}
