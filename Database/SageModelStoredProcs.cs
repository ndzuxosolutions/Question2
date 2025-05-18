using Microsoft.EntityFrameworkCore;

namespace Question2.Database
{
    public partial class SageModel
    {

        public virtual DbSet<SP_GetRecentOrders> SP_GetRecentOrders { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SP_GetRecentOrders>().HasNoKey();
        }

        public IEnumerable<SP_GetRecentOrders> GetRecentOrders()
        {
            return this.Set<SP_GetRecentOrders>().FromSqlRaw("EXECUTE dbo.GetRecentOrders");
        }
    }
}
