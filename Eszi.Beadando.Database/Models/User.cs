namespace Eszi.Beadando.Database.Models
{
    public class User
    {
        public long Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        // Cím, egyelőre useren tárolva, később esetleg ki lehet tenni külön entitásba, userhez több címet kötni, szállítási számlázási stb
        public required string ZipCode { get; set; }
        public required string City { get; set; }
        public required string Street { get; set; }
        public required string HouseNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = [];
        public virtual ICollection<CartItem> CartItems { get; set; } = [];
    }
}
