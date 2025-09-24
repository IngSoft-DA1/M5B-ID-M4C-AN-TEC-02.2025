using DataAccess;
using Domain;

namespace Services.Tests;

[TestClass]
public class MovieServiceTests
{
    private InMemoryDatabase _inMemoryDatabase;
    private MovieService _movieService;
    private Movie _movie;

    [TestInitialize]
    public void Setup()
    {
        _inMemoryDatabase = new InMemoryDatabase();
        _movieService = new MovieService(_inMemoryDatabase);
        _movie = new Movie("aTitle", "aDirector", new DateTime(2024, 07, 12), 2000000);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void AddMovie_WhenCalledTwiceWithSameMovie_ThenThrowsException()
    {
        //arrange
        //act
        _movieService.AddMovie(_movie);
        _movieService.AddMovie(_movie);
        //assert
    }

    [TestMethod]
    public void AddMovie_WhenCalled_ThenMovieIsAdded()
    {
        //arrange
        //act
        _movieService.AddMovie(_movie);
        //assert
        Movie? retrievedMovie = _inMemoryDatabase.GetMovie(_movie.Title);
        Assert.IsNotNull(retrievedMovie);
        Assert.IsTrue(_inMemoryDatabase.GetMovies().Count == 1);
    }

    [TestMethod]
    public void GetMovies_WhenCalledWithNoMovies_ThenNoMoviesAreReturned()
    {
        //arrange
        //act
        _movieService.GetMovies();
        //assert
        Assert.IsTrue(_inMemoryDatabase.GetMovies().Count == 0);
    }

    [TestMethod]
    public void GetMovies_WhenCalled_ThenAllMoviesAreReturned()
    {
        //arrange
        _inMemoryDatabase.AddMovie(_movie);
        //act
        _movieService.GetMovies();
        //assert
        Assert.IsTrue(_inMemoryDatabase.GetMovies().Contains(_movie));
        Assert.IsTrue(_inMemoryDatabase.GetMovies().Count == 1);
    }
}