using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record UpdateUserDto
    {
        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "O campo 'Nome' deve conter apenas letras e espaços.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "O campo 'Nome' deve ter entre {2} e {1} caracteres.")]
        public string? FirstName { get; set; }

        [RegularExpression(@"[A-Za-z ]+", ErrorMessage = "O campo 'Sobrenome' deve conter apenas letras e espaços.")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "O campo 'Sobrenome' deve ter entre {2} e {1} caracteres.")]
        public string? LastName { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "O campo 'Celular' deve ter entre {2} e {1} caracteres.")]
        public string? PhoneNumber { get; set; }
    }
}
