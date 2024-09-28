using LocaFilms.Enums;

namespace LocaFilms.Dtos.Response
{
    public record MovieDto(
        int Id,
        string Title,
        string SubTitle,
        string Description,
        string Duration,
        string Category,
        MovieStatusEnum Status,
        decimal CostPerDay,
        DateOnly ReleaseDate,
        DateTime RegistrationDateTime,
        DateTime LastModifiedDateTime,
        string ImageBannerUrl,
        string ImageIconUrl);
}
