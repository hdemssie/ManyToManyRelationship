using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCurd.Data;
using MovieCurd.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieCurd.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private ApplicationDbContext _db;
        //Get a list of all movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return this._db.Movies.ToList();
        }
        [HttpGet("{id}")] // HTTP Declaration with Id Object
        public IActionResult Get(int id)
        {
            Movie movieToReturn = _db.Movies.FirstOrDefault(m =>m.Id == id); 

            if(movieToReturn == null)
            {
                return NotFound();
            }
            else
            return Ok(movieToReturn);
        }

        //Add a movie or update an exisiting movie
        [HttpPost]

        public IActionResult Post([FromBody]Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            if (movie.Id == 0)
            {
                _db.Movies.Add(movie);
                _db.SaveChanges();
            } else
            {
                Movie originalMovie = _db.Movies.FirstOrDefault(mbox => mbox.Id == movie.Id);
                originalMovie.Title = movie.Title;
                originalMovie.Director = movie.Director;
                _db.SaveChanges();
             }
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToDelete = _db.Movies.FirstOrDefault(m => m.Id == id);
            if (movieToDelete == null)
            {
                return NotFound();
            }
            else
            {
                _db.Movies.Remove(movieToDelete);
                _db.SaveChanges();
                return Ok();
            }
        }



        //Constrator utilizing independcy injection
        public MoviesController(ApplicationDbContext db)
        {
            this._db = db;
        }
    }
}
