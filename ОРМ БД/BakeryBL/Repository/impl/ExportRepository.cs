using System.Data.Entity;

namespace BakeryBL.Repository.impl
{
    public class ExportRepository : DbContext
    {
        public ExportRepository() : base("CrmConnection") { }

        public DbSet<BakeryBL.Models.Export> Exports { get; set; }
    }
}
