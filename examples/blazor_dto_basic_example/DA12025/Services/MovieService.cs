using Domain;
using DataAccess;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class MovieService : IMovieService
    {
        private readonly InMemoryDatabase _inMemoryDatabase;

        public MovieService(InMemoryDatabase inMemoryDatabase)
        {
            _inMemoryDatabase = inMemoryDatabase;
        }

        public void AddMovie(MovieDTO movie)
        {
            ValidateUniqueTitle(movie.Title);
            _inMemoryDatabase.AddMovie(ToEntity(movie));
        }

        public List<MovieDTO> GetMovies()
        {
            List<MovieDTO> moviesDTO = new List<MovieDTO>();

            foreach (var movie in _inMemoryDatabase.GetMovies())
            {
                moviesDTO.Add(FromEntity(movie));
            }

            return moviesDTO;
        }

        public MovieDTO GetMovie(string title)
        {
            Movie? movie = _inMemoryDatabase.GetMovie(title);
            if (movie == null)
            {
                throw new ArgumentException("Cannot find movie with this title");
            }

            return FromEntity(movie);
        }

        private void ValidateUniqueTitle(string title)
        {
            foreach (var movie in _inMemoryDatabase.GetMovies())
            {
                if (movie.Title == title)
                {
                    throw new ArgumentException("There`s a movie already defined with that title");
                }
            }
        }

        private static Movie ToEntity(MovieDTO movieDTO)
        {
            return new Movie(movieDTO.Title, movieDTO.Director, movieDTO.ReleaseDate, movieDTO.Budget);
        }

        private static MovieDTO FromEntity(Movie movie)
        {
            return new MovieDTO()
            {
                Title = movie.Title,
                Director = movie.Director,
                ReleaseDate = movie.ReleaseDate
            };
        }
    }
}