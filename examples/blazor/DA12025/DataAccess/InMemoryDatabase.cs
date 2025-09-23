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

        public Movie GetMovie(string title)
        {
            foreach (var movieInList in _movies)
            {
                if (movieInList.Title.Equals(title))
                {
                    return movieInList;
                }
            }
            return null;
        }
        
        public void RemoveMovie(string title)
        {
            _movies.Remove(_movies.First(c => c.Title.ToLower().Equals(title.ToLower())));
        }

        public void UpdateMovie(Movie movie)
        {
            foreach (var movieInList in _movies)
            {
                movieInList.Title = movie.Title;
                movieInList.ReleaseDate = movie.ReleaseDate;
                movieInList.Director = movie.Director;
            }
        }

        
    }
}