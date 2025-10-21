namespace Services.Models;

public class MovieDTO
{
    public int? Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Budget { get; set; }

    public MovieDTO() { }

    public MovieDTO(int? id, string title, string director, DateTime releaseDate, int budget)
    {
        Id = id;
        Title = title;
        Director = director;
        ReleaseDate = releaseDate;
        Budget = budget;
    }
}