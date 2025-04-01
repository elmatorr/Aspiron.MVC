using Aspiron.MVC.Contracts;
using Aspiron.MVC.Repositories;
using Aspiron.MVC.Services;

namespace ConfigUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Register ConfigFileRepository with the file path
            builder.Services.AddScoped<IConfigRepository>(provider =>
            {
                var env = provider.GetRequiredService<IWebHostEnvironment>();
                var filePath = Path.Combine(env.WebRootPath, "App_Data");
                return new ConfigFileRepository(filePath);
            });

            builder.Services.AddScoped<IConfigService, ConfigService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
