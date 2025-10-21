using Services.Models;

namespace Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieDTO> GetMovies();
        MovieDTO GetMovie(string title);
        void AddMovie(MovieDTO movie);
        void UpdateMovie(MovieDTO movie);
        void DeleteMovie(string title);
    }
}