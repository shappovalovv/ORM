using System.Data.Entity;

namespace BakeryBL.Repository.impl
{
    public class ShopRepository : DbContext
    {
        public ShopRepository() : base("CrmConnection") { }

        public DbSet<BakeryBL.Models.Shop> Shops { get; set; }
    }
}
