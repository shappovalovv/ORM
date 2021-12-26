using System.Collections.Generic;

namespace BakeryBL.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Export> Exports { get; set; } 

        public override string ToString()
        {
            return Name;
        }
    }
}
