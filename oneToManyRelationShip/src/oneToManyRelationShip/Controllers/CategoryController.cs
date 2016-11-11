using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using oneToManyRelationShip.Data;
using oneToManyRelationShip.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace oneToManyRelationShip.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            this._db = db;
        }
        //Get all categories and the movies associated with them
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var categories = (from c in _db.Categories
                              select new Category
                              {
                                  Name = c.Name,
                                  Movies = (from m in c.Movies
                                            select new Movie
                                            {
                                                Title = m.Title,
                                                Director = m.Director
                                            }).ToList()
                              }).ToList();

            return categories;
        }
    }
}

