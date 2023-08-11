using System;
using Microsoft.EntityFrameworkCore;
using Units.Core;

namespace Units.Infrastructure.Data
{
    public class ConversionDbContext : DbContext
    {
        public ConversionDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Conversion> Conversions {get; set;} = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var ConversionDbContextAsembly = typeof(ConversionDbContext).Assembly;

            modelBuilder.ApplyConfigurationsFromAssembly(ConversionDbContextAsembly);
        }
    }
}
