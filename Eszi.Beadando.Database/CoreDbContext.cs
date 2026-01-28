using Eszi.Beadando.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Eszi.Beadando.Database
{
    public class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContext(options)
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
