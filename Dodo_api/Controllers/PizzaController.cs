using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dodo_api.Repository;
using Dodo_api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Dodo_api.Controllers
{
    [Route("api/[controller]")]
    public class PizzaController : Controller
    {
        private IPizzaRepository db;
        public PizzaController(IPizzaRepository context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<PizzaItem> GetAll()
        {
            return db.GetAll();
        }

        [HttpGet("sort={sort}")]
        public IEnumerable<PizzaItem> GetAll(string sort)
        {
            return db.GetAll(sort);
        }

        [HttpGet("{id}")]
        public PizzaItem GetById(int id)
        {
            return db.Find(id);
        }

        [HttpPost]
        public void Create(string ingids, PizzaItem item)
        {
            db.Add(ingids, item);

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, string ingids, PizzaItem item)
        {

            var pizza = db.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Update(id, ingids, item);
            return new NoContentResult();
        }

        [HttpPut]
        public IActionResult Update(int pizzaid, long ingid)
        {
            db.AddIngridient(pizzaid, ingid);
            return new NoContentResult();
        }

        [HttpDelete]
        public IActionResult Delete (int pizzaid, long ingid)
        {
            db.DelIngridient(pizzaid, ingid);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = db.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Remove(id);
            return new NoContentResult();
        }


    }
}
