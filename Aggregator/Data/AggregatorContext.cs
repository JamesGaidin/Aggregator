using Aggregator.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Aggregator.Data
{
    public class AggregatorContext : IdentityDbContext<AppUser>
    {
        public AggregatorContext(DbContextOptions<AggregatorContext> options) : base(options) { }

        public DbSet<CollectionItem> CollectionItems { get; set; } = null!;
    }
}
