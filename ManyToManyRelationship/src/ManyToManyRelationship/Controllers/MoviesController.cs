using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ManyToManyRelationship.Data;
using ManyToManyRelationship.Models;
using System.Collections;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ManyToManyRelationship.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        public MoviesController(ApplicationDbContext db)
        {
            _db = db;
        }
        //Get a list of all movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _db.Movies.ToList();
        }
        [HttpGet("{id}")]
        public Movie Get(int id)
        {
            return _db.Movies.Where(m => m.Id == id).FirstOrDefault();
            
        }

        //Post to /api/movies
        [HttpPost("{id}")]

        public IActionResult post(int id, [FromBody] Actor actor)
        {
            _db.Actors.Add(actor);
            _db.SaveChanges();
            _db.MovieActors.Add(new MovieActor
            {
                MovieId = id,
                ActorId =actor.Id
            });
            _db.SaveChanges();
            return Ok();
        }
    }
}
