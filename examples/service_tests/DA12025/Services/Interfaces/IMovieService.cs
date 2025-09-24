using Domain;

namespace Services.Interfaces;

public interface IMovieService
{
    List<Movie> GetMovies();
    void AddMovie(Movie movie);
}