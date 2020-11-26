using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Dodo_api.Models
{
    public class AdditionalItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }

        [JsonIgnore]
        public virtual ICollection<PizzaItem> PizzaItems { get; set; }
        public AdditionalItem()
        {
            PizzaItems = new List<PizzaItem>();
        }
    }
}
