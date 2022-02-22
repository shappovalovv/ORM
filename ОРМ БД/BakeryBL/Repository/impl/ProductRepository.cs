
using System.Data.Entity;

namespace BakeryBL.Repository.impl
{
    public class ProductRepository : DbContext
    {
        public ProductRepository() : base("CrmConnection") { }

        public DbSet<BakeryBL.Models.Product> Products { get; set; }

    }
}
