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
            
            if(dbContext.Database.GetPendingMigrations().Any())
            {
                app.Logger.LogInformation("-------Applying pending migrstions.....");
                dbContext.Database.Migrate();
                app.Logger.LogInformation("------Database successfully migrated...");
            }
            else
            {
                app.Logger.LogInformation("---->>There are no pending migrations.....");
            }
            //seed conversion rates
            ConversionDbContextSeed.SeedConversionDataAsync(dbContext);

        }
        
    }
}
