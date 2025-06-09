using Aggregator.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Aggregator.Data
{
    public class AggregatorContext : DbContext
    {
        public AggregatorContext(DbContextOptions<AggregatorContext> options) : base(options) { }

        public DbSet<CollectionItem> CollectionItems { get; set; }
    }
}
