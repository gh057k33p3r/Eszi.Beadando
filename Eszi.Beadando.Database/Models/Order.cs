namespace Eszi.Beadando.Database.Models
{
    public class Order
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; } = [];
    }
}
