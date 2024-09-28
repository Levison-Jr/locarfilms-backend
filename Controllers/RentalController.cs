using AutoMapper;
using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Models;
using LocaFilms.Services;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        private readonly IMapper _mapper;
        public RentalController(IRentalService rentalService, IMapper mapper)
        {
            _rentalService = rentalService;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalService.GetById(id);

            if (rental == null)
                return NotFound();

            return Ok(_mapper.Map<MovieRentals?, RentalDto>(rental));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RentalDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetRentalByUserId(string id)
        {
            var rentals = await _rentalService.GetByUserId(id);
            var result = _mapper.Map<IEnumerable<MovieRentals>, IEnumerable<RentalDto>>(rentals);
            
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("{userId}/{movieId:int}")]
        public async Task<IActionResult> GetRentalByUserMovieIds(string userId, int movieId)
        {
            var rental = await _rentalService.GetByUserMovieIds(userId, movieId);

            if (rental == null)
                return NotFound();

            return Ok(_mapper.Map<IEnumerable<RentalDto>>(rental));
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(RentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        public async Task<IActionResult> CreateRental(CreateRentalDto createRentalDto)
        {
            var movieRental = _mapper.Map<CreateRentalDto, MovieRentals>(createRentalDto);
            var result = await _rentalService.CreateRental(movieRental);

            if (!result.Success)
                return BadRequest(new ProblemDetails
                {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                });

            return CreatedAtAction(
                actionName: nameof(GetRentalByUserMovieIds),
                routeValues: new { userId = movieRental.UserId, movieId = movieRental.MovieId },
                value: _mapper.Map<MovieRentals?, RentalDto>(result.MovieRental));
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.isEmployee)]
        [HttpPut]
        public async Task<IActionResult> UpdateRental(UpdateRentalDto updateRentalDto)
        {
            var movieRental = _mapper.Map<UpdateRentalDto, MovieRentals>(updateRentalDto);
            var result = await _rentalService.UpdateRental(movieRental);

            if (!result.Success)
                return BadRequest(new ProblemDetails
                {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                });

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var result = await _rentalService.DeleteRental(id);

            if (!result.Success)
                return BadRequest(new ProblemDetails
                {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                });

            return NoContent();
        }
    }
}
