using System;
using Microsoft.EntityFrameworkCore;
using Units.Infrastructure.Data;


namespace Units.Api.Extension
{
    public static  class MigrationExtensions
    {
        public static void ApplyMigrations(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<ConversionDbContext>();

            //seed conversion rates
            ConversionDbContextSeed.SeedConversionDataAsync(dbContext);

            dbContext.Database.Migrate();
        }
        
    }
}
