using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using oneToManyRelationShip.Data;
using oneToManyRelationShip.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace oneToManyRelationShip.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller
    {
        private ApplicationDbContext _db;
        public  MovieController(ApplicationDbContext db)
        {
            this._db = db;
        }
        //Get all movies
        //api/movie
        [HttpGet]
        public IEnumerable<Movie> Get()
           
        {
            var movies = from m in _db.Movies
                         select new Movie
                         {
                             Title = m.Title,
                             Director = m.Director,
                             Category = m.Category
                         };

            return movies.ToList();
           
        }
    }
}
