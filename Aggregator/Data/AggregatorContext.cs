// Aggregator Solution - ASP.NET Core 8 Web API + Identity + JWT

using Aggregator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aggregator.Data
{
    public class AggregatorContext : IdentityDbContext<AppUser>
    {
        public AggregatorContext(DbContextOptions<AggregatorContext> options)
            : base(options) { }

        public DbSet<CollectionItem> CollectionItems { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CollectionItem>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();  // <-- ensures EF treats this as auto-generated
        }
    }
}
