using System.Collections.Generic;
using MovieCurd.Repository;

namespace MovieCurd.Interface
{
    public interface IMovieService
    {
        void DeleteMovie(int id);
        IList<Movie> GetAllMovies();
        Movie GetMoviebyId(int id);
        void SaveMovie(Movie movie);
        List<Movie> SearchByDirector(string searchTerm);
    }
}