using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryBL.Models
{
    public class Export
    {
        public int ExportId { get; set; } 
        public int ShopId { get; set; } 
        public int ProductId { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual Product Product { get; set; }
    }
}
