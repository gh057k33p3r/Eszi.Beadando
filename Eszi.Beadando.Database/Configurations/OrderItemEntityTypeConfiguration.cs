using Eszi.Beadando.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eszi.Beadando.Database.Configurations
{
    internal class OrderItemEntityTypeConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            // Összetett kulcs, több többes kapcsolótábla Order és Product között
            builder
                .HasKey(x => new { x.OrderId, x.ProductId });

            builder
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(o => o.OrderId);

            builder
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(o => o.ProductId);
        }
    }
}
