using System.ComponentModel.DataAnnotations;

namespace onlineStore.Core.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}