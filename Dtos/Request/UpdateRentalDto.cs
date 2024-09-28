using LocaFilms.Enums;
using System.ComponentModel.DataAnnotations;

namespace LocaFilms.Dtos.Request
{
    public record UpdateRentalDto
    {
        [Required(ErrorMessage = "O campo RentalId é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo RentalEndDate é obrigatório.")]
        public DateTime? RentalEndDate { get; set; }

        [EnumDataType(typeof(RentalStatusEnum), ErrorMessage = "O valor para RentalStatus é inválido.")]
        public RentalStatusEnum RentalStatus { get; set; }

        [EnumDataType(typeof(PaymentStatusEnum), ErrorMessage = "O valor para PaymentStatus é inválido.")]
        public PaymentStatusEnum PaymentStatus { get; set; }
    }
}
