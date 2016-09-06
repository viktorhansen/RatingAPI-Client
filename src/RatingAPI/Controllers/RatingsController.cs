using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingAPI.Models;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using System.Net;

namespace RatingAPI.Controllers
{
    // Allows for external access to api
    [EnableCors("AllowAnyOrigin")]
    // route to this controller: api/ratings
    [Route("api/[controller]")]
    // Every method returning HttpResponse as well as an object where relevant
    public class RatingsController : Controller
    {
        // Using the interface
        public IRatingsRepository RatingsRepo { get; set; }

        public RatingsController(IRatingsRepository repo)
        {
            RatingsRepo = repo;
        }

        // GET api/ratings
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RatingsRepo.GetAll());
        }

        // GET api/ratings/5
        [HttpGet("{id}", Name = "GetRating")]
        public IActionResult Get(int id)
        {
            var item = RatingsRepo.GetById(id);
            if (item == null)
            {
                return NotFound("Item requested was not found");
            }
            return Ok(item);
        }

        // POST api/ratings
        [HttpPost]
        public IActionResult Post([FromBody]Rating item)
        {
            if (item == null)
            {
                return BadRequest("Item to create can not be null");
            }
            var tmpItem = RatingsRepo.Add(item);
            return CreatedAtRoute("GetRating", new { id = item.Id }, tmpItem);
        }


         //PUT api/ratings/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Rating item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest("Item to be changed can not be null and have to have a matching db item id");
            }

            var tmpItem = RatingsRepo.GetById(id);
            if (tmpItem == null)
            {
                return NotFound("Item requested could not be found");
            }

            RatingsRepo.Update(item);
            return new NoContentResult();
        }

        // DELETE api/ratings/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = RatingsRepo.GetById(id);
            if (item == null)
            {
                return NotFound("Item requested could not be found");
            }

            RatingsRepo.Remove(id);
            return new NoContentResult();
        }
    }
}
