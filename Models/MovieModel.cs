using LocaFilms.Enums;
using System.Text.Json.Serialization;

namespace LocaFilms.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? SubTitle { get; set; }
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Category { get; set; }
        public MovieStatusEnum Status { get; set; }
        public decimal CostPerDay { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public string ImageBannerUrl { get; set; }
        public string ImageIconUrl { get; set; }

        [JsonIgnore]
        public IList<MovieRentals> MovieRentals { get; set; }
    }
}
