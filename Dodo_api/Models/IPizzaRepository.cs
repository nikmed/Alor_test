using System;
using System.Collections.Generic;

namespace Dodo_api.Models
{
    public interface IPizzaRepository
    {
        void Add(PizzaItem item);
        IEnumerable<PizzaItem> GetAll();
        PizzaItem Find(int pizzaid);
        PizzaItem Remove(int pizzaid);
        void Update(int id, PizzaItem item);
    }
}
