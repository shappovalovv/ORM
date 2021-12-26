using System.Data.Entity;

namespace BakeryBL.Models
{
    public class CrmDbContext : DbContext
    {
        public CrmDbContext() : base("CrmConnection") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Export> Exports { get; set; }         
    }
}
