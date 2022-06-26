namespace onlineStore.Core.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public string? PasswordHash { get; set; }
        
        public UserToken? UserToken { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}