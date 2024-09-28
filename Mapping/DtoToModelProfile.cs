using AutoMapper;
using LocaFilms.Dtos.Request;
using LocaFilms.Enums;
using LocaFilms.Models;

namespace LocaFilms.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<CreateUserDto, UserModel>()
                .ForMember(dest =>
                dest.Balance,
                opt => opt.MapFrom(_ => 0));

            CreateMap<UpdateUserDto, UserModel>();

            CreateMap<CreateMovieDto, MovieModel>()
                .ForMember(dest =>
                dest.Status,
                opt => opt.MapFrom(_ => MovieStatusEnum.isAvailable))

                .ForMember(dest =>
                dest.RegistrationDateTime,
                opt => opt.MapFrom(_ => DateTime.Now))
                
                .ForMember(dest =>
                dest.LastModifiedDateTime,
                opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateMovieDto, MovieModel>()
                .ForMember(dest =>
                dest.LastModifiedDateTime,
                opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<CreateRentalDto, MovieRentals>();

            CreateMap<UpdateRentalDto, MovieRentals>();
        }
    }
}
