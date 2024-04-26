using DrinkShopWebApp2.Data;
using Microsoft.EntityFrameworkCore;
//??using Microsoft.Extensions.DependencyInjection;

namespace DrinkShopWebApp2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<DrinkShopWebAppDbContext>(options => options.UseSqlServer(builder
                .Configuration.GetConnectionString("DrinkShopWebAppDatabase") ?? throw new InvalidOperationException("Connection string 'DrinkShopWebAppDatabase' not found.")));
            // NOTE: it is bad practice to store your connection strings w/ your code.
            // Use better practice to store connection string than having the configuration in
            // the ‘appsetting.json’ file. see below:
            // Secure connection string guidance: https://aka.ms/ef-core-connection-strings 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
