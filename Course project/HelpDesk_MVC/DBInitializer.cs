﻿using HelpDesk_MVC.Contracts.Exceptions;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace HelpDesk_MVC
{
    internal static class DBInitializer
    {
        public static void InitializeDB(IServiceProvider provider)
        {
            if (!ApplyMigrations(provider))
            {
                throw new DbInitializationException("Could not initialize DB! See errors above.");
            }
        }

        private static bool ApplyMigrations(IServiceProvider provider)
        {
            var logger = provider.GetRequiredService<ILogger>();
            logger.Information("Applying migrations...");

            var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DbContext>();

            try
            {
                context.Database.Migrate();
                logger.Information("Migration(s) applied!");
            }
            catch (Exception ex)
            {
                logger.Error("Database.Migrate failed!");
                logger.Error(ex.ToString());
                return false;
            }
            return true;
        }
    }
}
