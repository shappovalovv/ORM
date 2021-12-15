using System;
using System.Collections.Generic;

namespace CrmBL.Models
{
    public class Check
    {
        public int CheckId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"№{CheckId} от {Created:dd.MM.yy hh:mm:ss}";
        }
    }
}
