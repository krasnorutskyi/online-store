namespace onlineStore.Core.Entities
{
    public class Order : EntityBase
    {
        public List<Item> Items { get; set; } = new List<Item>();
       
        public User User { get; set; }
    }
}