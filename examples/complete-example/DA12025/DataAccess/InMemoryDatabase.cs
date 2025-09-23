using Domain;

namespace DataAccess
{
    public class InMemoryDatabase
    {
        private List<Movie> _movies { get; set; }

        public InMemoryDatabase()
        {
            _movies = new List<Movie>();
            LoadDefaultMovies();
        }

        private void LoadDefaultMovies()
        {
            _movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22)));
        }

        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }

        public void DeleteMovie(string title)
        {
            _movies.RemoveAll(m => m.Title == title);
        }

        public void UpdateMovie(Movie movie)
        {
            var index = _movies.FindIndex(m => m.Title == movie.Title);
            _movies[index] = movie;
        }
        
        public List<Movie> GetMovies() => _movies;
        
        public Movie GetMovie(string title) => _movies.FirstOrDefault(m => m.Title.Equals(title));
        
    }
}
