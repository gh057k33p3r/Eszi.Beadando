using Eszi.Beadando.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eszi.Beadando.Database.Configurations
{
    internal class CartItemEntityTypeConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            // Több többes kapcsolótábla, User és Product között
            builder
                .HasKey(ci => new { ci.ProductId, ci.UserId });

            builder
                .HasOne(ci => ci.User)
                .WithMany(u => u.CartItems)
                .HasForeignKey(u => u.UserId);

            builder
                .HasOne(ci => ci.Product)
                .WithMany(p => p.CartItems)
                .HasForeignKey(u => u.ProductId);
        }
    }
}
