using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class MovieDTO
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Budget { get; set; }
        
        public MovieDTO() {}

        public MovieDTO(string title, string director, DateTime releaseDate, int budget)
        {
            Title = title;
            Director = director;
            ReleaseDate = releaseDate;
            Budget = budget;
        }
    }
}