using System;
using System.Collections.Generic;

namespace BakeryBL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ShopId { get; set; }
        public virtual Shop Shop { get; set; }       
        public DateTime Created { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Export> Exports { get; set; } 
        public decimal Price { get; set; }

        public override string ToString()
        {
            return $"№{OrderId} от {Created:dd.MM.yy hh:mm:ss}";

        }
    }
}
