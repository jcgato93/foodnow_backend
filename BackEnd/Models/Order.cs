using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public int BranchId { get; set; }

        [Required]
        public int PayTypeId { get; set; }

        [Required]
        public int StateId { get; set; }


        // Monto pagado por el pedido
        [Required]
        public double Paid { get; set; }


        // Monto devuelto  (devuelta)
        public double? Returned { get; set; }


        // Dia y hora en la que ingresa la orden
        [Required]
        public DateTime OrderReceived { get; set; }

        // Dia y hora en la que se despacha la orden
        public DateTime? OrderDelivered { get; set; }


        public virtual ICollection<Sale> Sales { get; set; }


        // ====== Foraneas ===============
        [ForeignKey(nameof(BranchId))]
        public virtual Branch Branch { get; set; }

        [ForeignKey(nameof(PayTypeId))]
        public virtual PayType PayType { get; set; }

        [ForeignKey(nameof(StateId))]
        public virtual State State { get; set; }

    }
}
