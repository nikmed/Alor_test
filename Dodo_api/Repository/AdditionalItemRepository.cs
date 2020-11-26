using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using Dodo_api.Models;

namespace Dodo_api.Repository
{
    public class AdditionalItemRepository : IAdditionalItemRepository
    {
        private PizzaContext db;
        public AdditionalItemRepository(PizzaContext context)
        {
            db = context;
        }

        public IEnumerable<AdditionalItem> GetAll()
        {
            return db.AdditionalItems;
        }

        public void Add(AdditionalItem item)
        {
            db.AdditionalItems.Add(item);
            db.SaveChanges();
        }


        public AdditionalItem Find(long ingid)
        {
            AdditionalItem item;
            item = db.AdditionalItems.Find(ingid);
            return item;
        }


        public AdditionalItem Remove(long ingid)
        {
            AdditionalItem item;
            item = Find(ingid);
            db.AdditionalItems.Remove(item);
            db.SaveChanges();
            return item;
        }

        public void Update(long ingid, AdditionalItem item)
        {
            AdditionalItem olditem = db.AdditionalItems.Find(ingid);
            olditem.Name = item.Name;
            olditem.Image = item.Image;
            olditem.Price = item.Price;
            db.SaveChanges();
        }
    }
}

