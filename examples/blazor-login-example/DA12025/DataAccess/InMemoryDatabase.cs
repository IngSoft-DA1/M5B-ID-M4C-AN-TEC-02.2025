using Domain;

namespace DataAccess
{
    public class InMemoryDatabase
    {
        private List<Movie> Movies { get; }
        private List<User> Users { get; }

        public InMemoryDatabase()
        {
            Movies = new List<Movie>();
            Users = new List<User>();
            LoadDefaultMovies();
            LoadDefaultAdministratorUser();
        }

        public List<Movie> GetMovies()
        {
            return Movies;
        }

        public Movie? GetMovie(string title)
        {
            Movie? movie = Movies.FirstOrDefault(movie => movie.Title == title);
            return movie;
        }

        public void AddMovie(Movie movie)
        {
            Movies.Add(movie);
        }

        public List<User> GetUsers()
        {
            return Users;
        }

        public User? GetUser(string email)
        {
            User? user = Users.FirstOrDefault(user => user.Email == email);
            return user;
        }

        public void AddUser(User user)
        {
            Users.Add(user);
        }

        private void LoadDefaultMovies()
        {
            
            Movies.Add(new Movie("Cast Away", "Robert Zemeckis", new DateTime(2000, 12, 22), 25000000));
        }

        private void LoadDefaultAdministratorUser()
        {
            Users.Add(new User("Alumno", "Ort", "alumno@ort.edu.uy", "123456", "User"));
        }
    
    }
}