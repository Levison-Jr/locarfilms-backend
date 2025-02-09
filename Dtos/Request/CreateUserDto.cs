using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record CreateUserDto
    {
        [Required(ErrorMessage = $"O campo {nameof(Email)} é obrigatório.")]
        [EmailAddress(ErrorMessage = $"O campo {nameof(Email)} é inválido.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo 'Password' é obrigatório.")]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z0-9._@!#$%&+-]{5,20}$", ErrorMessage = $"A senha deve conter letra maiúscula, minúscula e número. Entre 5 e 20 caracteres. Símbolos permitidos: ._@!#$%&+-")]
        public string? Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = $"Os campos {nameof(Password)} e {nameof(PasswordConfirm)} devem ser iguais.")]
        public string? PasswordConfirm { get; set; }
    }
}
