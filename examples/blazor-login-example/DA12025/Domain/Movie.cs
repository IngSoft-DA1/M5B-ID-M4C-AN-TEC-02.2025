namespace Domain;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Budget { get; set; }

    public Movie(string title, string director, DateTime releaseYear, int budget)
    {
        Title = title;
        Director = director;
        ReleaseDate = releaseYear;
        Budget = budget;
    }
}