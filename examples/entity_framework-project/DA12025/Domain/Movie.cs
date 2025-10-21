namespace Domain;

public class Movie
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Budget { get; set; }

    public Movie() { }

    public Movie(int? id, string title, string director, DateTime releaseYear, int budget)
    {
        Id = id;
        Title = title;
        Director = director;
        ReleaseDate = releaseYear;
        Budget = budget;
    }
}