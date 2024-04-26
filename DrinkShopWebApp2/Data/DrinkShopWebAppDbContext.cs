using DrinkShopWebApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace DrinkShopWebApp2.Data
{
    public class DrinkShopWebAppDbContext : DbContext
    {
        public DrinkShopWebAppDbContext(DbContextOptions options) : base(options)
        {
        }

        /*public virtual DbSet<Drink> Drinks { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }*/
        
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Drink> Drinks { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        // When console app rather than web app had below OnConfiguration() method
        // in the DrinkShopWebAppDbContext.cs file - for web app removed below
        // method from the DrinkShopWebAppDbContext.cs file and added - 
        // builder.Services.AddDbContext() which then got the connection string
        // into the Program.cs file. 
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\xxx;Initial Catalog=DrinkShopWebAppDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            // hard coding a connection string like above is bad practice – only doing
            // this way for demo purposes – should always use a secure
            // storage method for real-world connection strings. 
            // For secure connection string guidance: https://aka.ms/ef-core-connection-strings 
        }*/

    }
}
