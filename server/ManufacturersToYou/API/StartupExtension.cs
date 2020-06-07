using System;
using API;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Persistence;
using Microsoft.Extensions.Configuration;

namespace ExtensionMethods
{
    public static class StartupExtension
    {
        public static void AddDbContextExtension(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("DefaultConnection"));
            });
        }
        public static void UseCustomConfigureForMigrateAndSeedDb(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                    var db = context.Database;
                    db.EnsureCreated();
                    db.Migrate();
                    Seed.SeedData(context);
                }
                catch(Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occured during migration");
                }
            }
        }
    }
}