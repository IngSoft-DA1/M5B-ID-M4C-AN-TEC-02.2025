using Services.Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetMovies();
        void AddMovie(MovieDTO movie);
        MovieDTO GetMovie(string title);
    }
}
