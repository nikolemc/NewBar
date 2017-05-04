using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace McStanleyBar.Models
{
    public class Ticket
    {
        [Key]        
        public int Id { get; set; }
        public Guid Barcode { get; set; } = Guid.NewGuid();

        [DataType(DataType.Date)]
        public DateTime? DatePurchased { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double PurchasePrice { get; set; }


        public bool WasUsed { get; set; } = false;

        // navigation prop

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }

        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}