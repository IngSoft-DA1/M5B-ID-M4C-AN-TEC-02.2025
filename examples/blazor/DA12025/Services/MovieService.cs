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
            if (!ValidateUniqueTitle(movie.Title))
            {
                throw new ArgumentException("There already exists an entry under this title");
            }
            _inMemoryDatabase.AddMovie(movie);
        }

        public List<Movie> GetMovies()
        {
            return _inMemoryDatabase.GetMovies();
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

        public void RemoveMovie(Movie movie)
        {
            if (!ValidateUniqueTitle(movie.Title))
            {
                throw new ArgumentException("There does not exist an entry under this title");
            }
            _inMemoryDatabase.RemoveMovie(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            if (!ValidateUniqueTitle(movie.Title))
            {
                throw new ArgumentException("There does not exist an entry under this title");
            }
            _inMemoryDatabase.UpdateMovie(movie);
        }

        private bool ValidateUniqueTitle(String title)
        {
            return (_inMemoryDatabase.GetMovie(title)) == null;
        }
    }
}