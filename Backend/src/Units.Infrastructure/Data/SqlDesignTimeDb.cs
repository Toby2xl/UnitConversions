#if DEBUG //Runs only on Debug mode or in Development.


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Units.Infrastructure.Data;

namespace Inventory.Infrastructure.Data;

public class SqlDesignTimeDb : IDesignTimeDbContextFactory<ConversionDbContext>
{
    public ConversionDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<ConversionDbContext>();
        builder.UseNpgsql("Host = localhost; Username = postgres; Password = MCdonald12; Database = ConversionDB");
        return new ConversionDbContext(builder.Options);
    }
}
#endif