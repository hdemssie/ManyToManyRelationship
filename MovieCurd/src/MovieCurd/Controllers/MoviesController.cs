using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieCurd.Data;
using MovieCurd.Repository;
using MovieCurd.Interface;
using MovieCurd.Services;

namespace MovieCurd.Controllers
{
    
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private IMovieService _service; 
        //private ImovieRepository _repo;

        //Get a list of all movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return _service.GetAllMovies();
        }


        [HttpGet("{id}")] // HTTP Declaration with Id Object
        public IActionResult Get(int id)
        {
            return Ok(_service.GetMoviebyId(id));
        
        }

        //Add a movie or update an exisiting movie
        [HttpPost]
        public IActionResult Post([FromBody]Movie movie)
        {
            _service.SaveMovie(movie);
            return Ok(movie);
        }


        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            _service.DeleteMovie(id);
            return Ok();
        }



        //Constrator utilizing independcy injection
        public MoviesController(IMovieService service)
        {
            this._service = service;
        }
    }
}
