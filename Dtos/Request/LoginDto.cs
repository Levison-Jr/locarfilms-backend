using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record LoginDto
    {
        [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório.")]
        [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} é inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        public string? Password { get; set; }
    }
}
