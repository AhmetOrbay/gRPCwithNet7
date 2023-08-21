using gRPCwithDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace gRPCwithDotnet.Data
{
    public class gRPCDataContext : DbContext
    {
        public gRPCDataContext(DbContextOptions<gRPCDataContext> options) :base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasQueryFilter(x => !x.IsDelete);
        }
        public DbSet<Product> Products => Set<Product>();
    }
}
