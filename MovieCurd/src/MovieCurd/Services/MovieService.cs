using MovieCurd.Interface;
using MovieCurd.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCurd.Services
{
    public class MovieService:IMovieService 
    {
        private IGenericRepository _repo;
        public IList<Movie> GetAllMovies()
        {
            return _repo.Query<Movie>().ToList();
        }
        //Get single movie by Id(called by controller Get(id) method)
        public Movie GetMoviebyId(int id)
        {
            return _repo.Query<Movie>().Where(m => m.Id==id).FirstOrDefault();
        }
        //post single move to the database (called by Post(movie)   methiod)
        public void SaveMovie(Movie movie)
        {
            if(movie.Id == 0)
            {
                _repo.Add(movie);
            }
            else
            {
                _repo.Update(movie);
            }

        }
        //Delete singl movie from the database (called by Delete(id method)
        public void DeleteMovie(int id)
        {
            Movie movieTODelete = _repo.Query<Movie>().Where(m => m.Id == id).FirstOrDefault();
            _repo.Delete(movieTODelete);
        }
        public List<Movie> SearchByDirector(string searchTerm)
        {
            var Movies = _repo.Query<Movie>();
            return (from m in Movies
                    where m.Director == searchTerm
                    select new Movie
                    {

                        Title = m.Title,
                        Director = m.Director,
                    }).ToList();
        }

    public MovieService(IGenericRepository repo)
        {
        this._repo = repo;
        }
    }
}
