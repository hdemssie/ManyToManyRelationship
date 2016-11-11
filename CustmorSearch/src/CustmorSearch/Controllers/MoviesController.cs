using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CustmorSearch.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CustmorSearch.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        public static List<Movie> _movies = new List<Movie>()
        {
        new Movie { Id = 1, Title = "Star Wars: A New Hope", Director="Lucas" },
        new Movie { Id = 2, Title = "Jurassic Park ", Director="Spielberg" },
        new Movie { Id = 3, Title = "Star wars: The Empire Strikes Back", Director="Lucas"},
        new Movie { Id = 4, Title = "The Dar Kingt ", Director="Nolan"},
        };
        [HttpGet("search/{text}")]
        public IActionResult Get(String text)
        {
            List<Movie> results = new List<Movie>();
            foreach (Movie movie in _movies)

            {
                if (movie.Director.Contains(text))

                {
                    results.Add(movie);
                }

            }
            return Ok(results);
        }
    }


}
        

