using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using Dodo_api.Models;

namespace Dodo_api.Repository
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
            return db.PizzaItems.Include(p => p.AdditionalIngridients);
        }

        public IEnumerable<PizzaItem> GetAll(string sort)
        {
            IEnumerable<PizzaItem> items;
            switch (sort)
            {
                case "new":
                    items = db.PizzaItems.Where(p => p.IsNew == true);
                    break;
                case "active":
                    items = db.PizzaItems.Where(p => p.IsActive == true);
                    break;
                default:
                    items = db.PizzaItems.Where(p => p.Name == sort);
                    break;
            }
            return items;
        }


        public void Add(string ingids, PizzaItem item)
        {
            db.PizzaItems.Add(item);
            db.SaveChanges();
            try
            {
                StringBuilder clearingids = new StringBuilder();
                foreach (char c in ingids)
                {
                    if ((c >= '0' && c <= '9') || (c == ','))
                    {
                        clearingids.Append(c);
                    }
                }

                List<long> ids = clearingids.ToString().Split(',').Select(Int64.Parse).ToList();
            
                foreach (long ingid in ids)
                {
                    AddIngridient(item.Id, ingid);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }


        public PizzaItem Find(long pizzaid)
        {
            PizzaItem item;
            item = db.PizzaItems
                .Include(p => p.AdditionalIngridients)
                .Where(p => p.Id == pizzaid)
                .FirstOrDefault();
            return item;
        }


        public PizzaItem Remove(long pizzaid)
        {
            PizzaItem item;
            item = Find(pizzaid);
            db.PizzaItems.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(long id, string ingids, PizzaItem item)
        {
            PizzaItem olditem = db.PizzaItems.Find(id);
            olditem.Name = item.Name;
            olditem.Price = item.Price;
            olditem.Description = item.Description;
            olditem.Image = item.Image;
            olditem.Ingredients = item.Ingredients;
            olditem.IsActive = item.IsActive;
            olditem.IsNew = item.IsNew;
            olditem.Dough = item.Dough;
            olditem.OptionalIngredients = item.OptionalIngredients;
            try
            {
                StringBuilder clearingids = new StringBuilder();
                foreach (char c in ingids)
                {
                    if ((c >= '0' && c <= '9') || (c == ','))
                    {
                        clearingids.Append(c);
                    }
                }

                List<long> ids = clearingids.ToString().Split(',').Select(Int64.Parse).ToList();

                foreach (long ingid in ids)
                {
                    AddIngridient(item.Id, ingid);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                db.SaveChanges();
            }
        }
        

        public void AddIngridient (long pizzaid, long ingid)
        {
            PizzaItem item = db.PizzaItems
                .Include(p => p.AdditionalIngridients)
                .Where(p =>p.Id == pizzaid)
                .FirstOrDefault();
            AdditionalItem ingridient = db.AdditionalItems.Find(ingid);
            if (!item.AdditionalIngridients.Contains(ingridient))
            { 
                item.AdditionalIngridients.Add(db.AdditionalItems.Find(ingid));
            }
            db.SaveChanges();
        }

        public void DelIngridient(long pizzaid, long ingid)
        {
            PizzaItem item = db.PizzaItems
                .Include(p => p.AdditionalIngridients)
                .Where(p => p.Id == pizzaid)
                .FirstOrDefault();
            AdditionalItem ingridient = db.AdditionalItems.Find(ingid);
            if (item.AdditionalIngridients.Contains(ingridient))
            {
                item.AdditionalIngridients.Remove(db.AdditionalItems.Find(ingid));
            }
            db.SaveChanges();
        }
    }
}
