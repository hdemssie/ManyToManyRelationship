using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using movieProducts.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace movieProducts.wwwroot
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {


        static List<Movie> _movies = new List<Movie>
        {
            new Movie { Id=1, Name="The Godfather " },

            new Movie { Id=2, Name="Duck Soup" },

            new Movie { Id=3, Name="Mean Streets" }

        };
        public IEnumerable<Movie> Get()
        {
            return _movies;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Movie movie = _movies.Find(p => p.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            _movies.Add(movie);
            return Created("/movies/" + movie.Id, movie);
        
        }
    }
}
