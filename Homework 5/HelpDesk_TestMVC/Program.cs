using HelpDesk_BLL;
namespace HelpDesk_TestMVC

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
			
            Startup.AddServices(builder);
            //Startup.AddSerilog(builder);
			//Startup.RegisterDAL(builder.Services);
			HelpDesk_BLL_ModuleHead.RegisterModule(builder.Services);
			//Startup.RegisterEmployeeService(builder);
			

			var app = builder.Build();

            DBInitializer.InitializeDB(app.Services);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
