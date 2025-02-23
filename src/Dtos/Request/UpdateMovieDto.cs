using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record UpdateMovieDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string? Title { get; init; }

        [MaxLength(50)]
        public string? SubTitle { get; set; }

        [MaxLength(400)]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Description { get; init; }

        [MaxLength(5, ErrorMessage = "O formato da duração é: xx:xx")]
        [Required(ErrorMessage = "A duração é obrigatória.")]
        public string? Duration { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string? Category { get; init; }

        [EnumDataType(typeof(MovieStatusEnum), ErrorMessage = "O campo 'Status' é inválido.")]
        public MovieStatusEnum Status { get; set; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        [Range(0.01, 100, ErrorMessage = "O valor para 'CostPerDay' deve estar entre 0.01 e 100")]
        public decimal? CostPerDay { get; init; }

        [Required(ErrorMessage = "O data de lançamento é obrigatória.")]
        public DateOnly ReleaseDate { get; set; }

        public string? ImageBannerUrl { get; set; }

        public string? ImageIconUrl { get; set; }

        public string? YouTubeTraillerUrl { get; set; }
    }
}
