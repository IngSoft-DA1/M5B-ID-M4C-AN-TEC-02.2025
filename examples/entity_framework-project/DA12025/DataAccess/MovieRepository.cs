using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;

public class MovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context)
    {
        _context = context;
    }

    public void AddMovie(Movie movie)
    {
        try
        {
            _context.Set<Movie>().Add(movie);
            _context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Cannot add the movie to database", e);
        }
    }

    public List<Movie> GetMovies()
    {
        return _context.Set<Movie>().AsQueryable<Movie>().ToList();
    }

    public Movie GetMovie(Func<Movie, bool> filter)
    {
        return _context.Set<Movie>().FirstOrDefault(filter);
    }

    public void UpdateMovie(Movie movie)
    {
        try
        {
            _context.Update(movie);
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Cannot update the movie", e);
        }
    }

    public void DeleteMovie(Movie movie)
    {
        
        try
        {
            _context.Set<Movie>().Remove(movie);
            _context.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            throw new DbUpdateException("Cannot delete the movie", e);
        }
    }


}