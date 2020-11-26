using System;
using System.Collections.Generic;
using Dodo_api.Models;

namespace Dodo_api.Repository
{
    public interface IPizzaRepository
    {
        void Add(string ingids, PizzaItem item);
        IEnumerable<PizzaItem> GetAll();
        IEnumerable<PizzaItem> GetAll(string sort);
        PizzaItem Find(long pizzaid);
        PizzaItem Remove(long pizzaid);
        void Update(long id, string ingids, PizzaItem item);
        public void AddIngridient(long pizzaid, long ingid);
        public void DelIngridient(long pizzaid, long ingid);
    }
}
