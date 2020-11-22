using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dodo_api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        [HttpGet("{id}", Name = "GetTodo")]
        public PizzaItem GetById(int id)
        {
            return db.Find(id);
        }
        [HttpPost]
        public void Create(PizzaItem item)
        {
            db.Add(item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, PizzaItem item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var pizza = db.Find(id);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Update(id, item);
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
