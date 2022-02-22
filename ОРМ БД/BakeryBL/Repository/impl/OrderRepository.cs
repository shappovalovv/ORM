using System.Data.Entity;

namespace BakeryBL.Repository.impl
{
    public class OrderRepository : DbContext
    {
        public OrderRepository() : base("CrmConnection") { }

        public DbSet<BakeryBL.Models.Order> Orders { get; set; }
    }
}
