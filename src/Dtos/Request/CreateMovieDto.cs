using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record CreateMovieDto
    {
        [MaxLength(50)]
        [Required(ErrorMessage = "O título é obrigatório.")]
        public string? Title { get; set; }

        [MaxLength(50)]
        public string? SubTitle { get; set; }

        [MaxLength(400)]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string? Description { get; set; }

        [MaxLength(5, ErrorMessage = "O formato da duração é: xx:xx")]
        [Required(ErrorMessage = "A duração é obrigatória.")]
        public string? Duration { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "O custo é obrigatório.")]
        [Range(0.01, 100, ErrorMessage = "O valor do custo deve estar entre 0.01 e 100")]
        public decimal? CostPerDay { get; set; }

        [Required(ErrorMessage = "O data de lançamento é obrigatória.")]
        public DateOnly ReleaseDate { get; set; }

        [Required(ErrorMessage = "A imagem para o banner é obrigatória.")]
        public string? ImageBannerUrl { get; set; }

        [Required(ErrorMessage = "A imagem para o ícone é obrigatória.")]
        public string? ImageIconUrl { get; set; }

        public string? YouTubeTraillerUrl { get; set; }
    }
}
