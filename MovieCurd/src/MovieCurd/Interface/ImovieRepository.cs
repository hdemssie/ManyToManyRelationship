using System.Collections.Generic;

namespace MovieCurd.Repository
{
    public interface ImovieRepository
    {
        void CreateMovie(Movie movieToCreate);
        void DeleteMovie(int id);
      
        Movie FindMovie(int id);
        IList<Movie> ListMovies();
        void UpdateMovie(Movie movieToUpdate);
    }
}