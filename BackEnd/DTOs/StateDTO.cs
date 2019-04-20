using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.DTOs
{
    public class StateDTO
    {        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }


        public  ICollection<OrderDTO> Orders { get; set; }
    }
}
