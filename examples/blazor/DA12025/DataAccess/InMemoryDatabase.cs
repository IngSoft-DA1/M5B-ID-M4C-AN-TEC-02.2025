using Domain;

namespace DataAccess
{
    public class InMemoryDatabase
    {
        private List<Movie> _movies;

        public InMemoryDatabase()
        {
            _movies = new List<Movie>();
            LoadDefaultMovies();
        }

        private void LoadDefaultMovies()
        {
            _movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public Movie? GetMovie(string title)
        {
            Movie? movie = _movies.FirstOrDefault(movie => movie.Title == title);
            return movie;
        }

        public void RemoveMovie(Movie movie)
        {
            _movies.Remove(movie);
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            Movie? movie = _movies.Find(m => m.Title == movieToUpdate.Title);
            var movieToUpdateIndex = _movies.IndexOf(movie);
            _movies[movieToUpdateIndex] = movieToUpdate;
        }
    }
}