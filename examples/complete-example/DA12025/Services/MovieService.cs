using Domain;
using DataAccess;
using Services.Interfaces;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly InMemoryDatabase _inMemoryDatabase;

        public MovieService(InMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public void AddMovie(Movie movie)
        {
            if (ValidateUniqueTitle(movie.Title))
            {
                _inMemoryDatabase.AddMovie(movie);
            }

        }

        public void DeleteMovie(string title)
        {
            _inMemoryDatabase.DeleteMovie(title);
        }

        public List<Movie> GetMovies()
        {
            return _inMemoryDatabase.GetMovies();
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            _inMemoryDatabase.UpdateMovie(movieToUpdate);
        }

        public Movie GetMovie(string title)
        {
            Movie? movie = _inMemoryDatabase.GetMovie(title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }
            return movie;
        }

        private bool ValidateUniqueTitle(String title)
        {
            try
            {
                GetMovie(title);
            }
            catch (ArgumentException)
            {
                return true;
            }
            return false;
        }
    }
}