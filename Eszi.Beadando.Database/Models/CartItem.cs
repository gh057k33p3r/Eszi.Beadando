namespace Eszi.Beadando.Database.Models
{
    // Több több kapcsolótábla
    public class CartItem
    {
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public long ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public long Quantity { get; set; }
    }
}
