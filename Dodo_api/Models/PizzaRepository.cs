using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Dodo_api.Models
{

    public class PizzaRepository : IPizzaRepository
    {
        private PizzaContext db;
        public PizzaRepository(PizzaContext context)
        {
            db = context;
        }

        public IEnumerable<PizzaItem> GetAll()
        {
            return db.PizzaItems;
        }

        public void Add(PizzaItem item)
        {
            db.PizzaItems.Add(item);
            db.SaveChanges();
        }

        public PizzaItem Find(int pizzaid)
        {
            PizzaItem item;
            item = db.PizzaItems.Find(pizzaid);
            return item;
        }

        public PizzaItem Remove(int pizzaid)
        {
            PizzaItem item;
            item = Find(pizzaid);
            db.PizzaItems.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(int id, PizzaItem item)
        {
            PizzaItem olditem = db.PizzaItems.FirstOrDefault();
            olditem.Name = item.Name;
            olditem.Price = item.Price;
            olditem.Additional = item.Additional;
            olditem.Description = item.Description;
            olditem.Image = item.Image;
            olditem.Ingredients = item.Ingredients;
            olditem.IsActive = item.IsActive;
            olditem.IsNew = item.IsNew;
            db.PizzaItems.Update(olditem);
            db.SaveChanges();
        }
    }
}
