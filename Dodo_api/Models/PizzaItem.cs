using System;
namespace Dodo_api.Models
{
    public class PizzaItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        public string Additional { get; set; }
    }
}
