namespace onlineStore.Core.Entities
{
    public class Item : EntityBase
    {
        public string Name { get; set; }
        
        public Category Category { get; set; }
        
        public string Image { get; set; }
        public double Price { get; set; }
    }
}