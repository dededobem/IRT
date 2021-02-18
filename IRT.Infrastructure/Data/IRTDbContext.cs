using IRT.Domain.Entities;
using IRT.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IRT.Infrastructure.Data
{
    public class IRTDbContext : DbContext
    {
        public IRTDbContext(DbContextOptions<IRTDbContext> options)
            : base(options)
        {}

        public DbSet<Neighborhood> Neighborhoods { get; set; }
        public DbSet<Drugstore> Drugstores { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DrugstoreMap());
            modelBuilder.ApplyConfiguration(new NeighborhoodMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
