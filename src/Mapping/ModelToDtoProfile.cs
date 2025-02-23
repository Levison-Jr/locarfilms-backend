using AutoMapper;
using LocaFilms.Dtos.Response;
using LocaFilms.Models;

namespace LocaFilms.Mapping
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<UserModel, UserDto>();
            CreateMap<MovieModel, MovieDto>();
            CreateMap<MovieRentals, RentalDto>();
        }
    }
}
