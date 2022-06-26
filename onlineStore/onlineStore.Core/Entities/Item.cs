namespace onlineStore.Core.Entities
{
    public class Item : EntityBase
    {
        public int Article { get; set; }
        
        public string Name { get; set; }
        
        public Category Category { get; set; }
        
        public int Price { get; set; }
    }
}