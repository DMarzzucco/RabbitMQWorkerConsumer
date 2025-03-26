using Microsoft.EntityFrameworkCore;
using Project.Context;

namespace Project.Configuration.Database.Extensions
{
    public static class AutoMigrationDatabase
    {
        public static void ApplyMigration(this IHost app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
            dbContext.Database.Migrate();
        }
    }
}
