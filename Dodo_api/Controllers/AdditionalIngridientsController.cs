using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dodo_api.Repository;
using Dodo_api.Models;
using Microsoft.AspNetCore.Mvc;


namespace Dodo_api.Controllers
{
    [Route("api/adding")]
    public class AdditionalIngridientsController : Controller
    {
        private IAdditionalItemRepository db;
        public AdditionalIngridientsController(IAdditionalItemRepository context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<AdditionalItem> GetAll()
        {
            return db.GetAll();
        }

        [HttpGet("{id}")]
        public AdditionalItem GetById(int ingid)
        {
            return db.Find(ingid);
        }

        [HttpPost]
        public void Create(AdditionalItem item)
        {
            db.Add(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int ingid, AdditionalItem item)
        {

            var pizza = db.Find(ingid);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Update(ingid, item);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int ingid)
        {
            var pizza = db.Find(ingid);
            if (pizza == null)
            {
                return NotFound();
            }

            db.Remove(ingid);
            return new NoContentResult();
        }
    }
}
