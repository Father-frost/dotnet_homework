using HelpDesk_BLL.Contracts.Identity;
using HelpDesk_BLL.Services.Identity;
using HelpDesk_DAL;
using HelpDesk_TestMVC.ConfigurationSections;
using Microsoft.EntityFrameworkCore;
using Serilog;
using ILogger = Serilog.ILogger;

namespace HelpDesk_TestMVC
{
    public static class Startup
    {

        internal static void AddServices(WebApplicationBuilder builder)
        {
            AddSerilog(builder);
            RegisterDAL(builder);
            RegisterEmployeeService(builder);
		}


        public static void RegisterDAL(WebApplicationBuilder builder)
        {
            var services = builder.Services;

            var connectionString = builder.Configuration.GetConnectionString("Default");
            services.AddTransient<DbContextOptions<EmployeeDbContext>>(provider =>
            {
                var builder = new DbContextOptionsBuilder<EmployeeDbContext>();
                builder.UseSqlServer(connectionString);
                return builder.Options;
            });

            services.AddScoped<DbContext, EmployeeDbContext>();

            services.AddScoped<IUnitOfWork>(prov =>
            {
                var context = prov.GetRequiredService<DbContext>();
                return new UnitOfWork(context);
            });
        }

        internal static void AddSerilog(WebApplicationBuilder builder)
        {
			var serilogConfig = builder.Configuration.GetSection(nameof(SerilogConfig)).Get<SerilogConfig>();
			var logFilePath = Path.Combine(serilogConfig?.LoggingDir ?? "./", "log.txt");

			var loggerConfig = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logFilePath, rollingInterval: RollingInterval.Month,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}");

            if (builder.Environment.IsDevelopment())
            {
                loggerConfig = loggerConfig.MinimumLevel.Debug();
            }
            else
            {
                loggerConfig = loggerConfig.MinimumLevel.Warning();
            }

            var logger = loggerConfig.CreateLogger();

            builder.Services.AddSingleton<ILogger>(logger);
        }

		public static void RegisterEmployeeService(WebApplicationBuilder builder)
        {
			var provider = builder.Services.BuildServiceProvider();
			var logger = provider.GetRequiredService<ILogger>();

			if (builder.Environment.IsDevelopment())
			{
				logger.Information("Register EmployeeService if IsDevelopment ...");
				builder.Services.AddScoped<IEmployeeService, EmployeeService>();

			}
			else
			{
				logger.Information("Register StubEmployeeService if not IsDevelopment ...");
				builder.Services.AddScoped<IEmployeeService, StubEmployeeService>();
			}
		}

	}
}
