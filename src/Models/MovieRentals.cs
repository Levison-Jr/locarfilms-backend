using LocaFilms.Enums;
using System.Text.Json.Serialization;

namespace LocaFilms.Models
{
    public class MovieRentals
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int MovieId { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public RentalStatusEnum RentalStatus { get; set; }
        public PaymentStatusEnum PaymentStatus { get; set; }

        [JsonIgnore]
        public UserModel User { get; set; }

        public MovieModel Movie { get; set; }
    }
}
