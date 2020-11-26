using System;
using System.Collections.Generic;

namespace Dodo_api.Models
{
    public class PizzaItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string OptionalIngredients { get; set; }
        public bool IsActive { get; set; }
        public bool IsNew { get; set; }
        /// <summary>
        /// 1 - Only slim dough
        /// 2 - Only traditional dough
        /// 3 - Traditional and slim dough
        /// </summary>
        public byte Dough { get; set; }

        public virtual List<AdditionalItem> AdditionalIngridients { get; set; }
        public PizzaItem()
        {
            AdditionalIngridients = new List<AdditionalItem>();
        }

        public void AddAdditionalIngredients(List<AdditionalItem> additionalItems)
        {
            AdditionalIngridients.AddRange(additionalItems);
        }
    }
}
