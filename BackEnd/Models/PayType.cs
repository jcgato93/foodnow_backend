﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class PayType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string description { get; set; }


        public virtual ICollection<Order> Orders { get; set; }
    }
}
