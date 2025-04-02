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
            // Configure the JSON serialization options to preserve the property names' case.
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            // Register ConfigFileRepository with the file path
            builder.Services.AddScoped<IConfigRepository>(provider =>
            {
                var env = provider.GetRequiredService<IWebHostEnvironment>();
                var filePath = Path.Combine(env.WebRootPath, "App_Data");
                return new ConfigFileRepository(filePath);
            });

            builder.Services.AddScoped<IConfigService, ConfigService>();
            builder.Services.AddScoped<ITranslationService, TranslationService>();
            builder.Services.AddScoped<ICacheProvider, MemCacheProvider>();

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
