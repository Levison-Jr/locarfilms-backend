using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record LoginDto
    {
        [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório.")]
        [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} é inválido.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        public string? Password { get; set; }
    }
}
