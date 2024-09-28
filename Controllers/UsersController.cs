using AutoMapper;
using LocaFilms.Dtos.Request;
using LocaFilms.Dtos.Response;
using LocaFilms.Models;
using LocaFilms.Services;
using LocaFilms.Services.Communication;
using LocaFilms.Services.Identity;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocaFilms.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IIdentityService identityService,
            IUserService userService,
            IMapper mapper)
        {
            _identityService = identityService;
            _userService = userService;
            _mapper = mapper;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.isEmployee)]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var result = _mapper.Map<IEnumerable<UserModel>, IEnumerable<UserDto>>(users);

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize(Policy = Policies.isEmployee)]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            UserModel? user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(_mapper.Map<UserModel, UserDto>(user));
        }

        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrEmpty(createUserDto.Email) || string.IsNullOrEmpty(createUserDto.Password))
                return BadRequest();

            var result = await _identityService.Register(createUserDto.Email, createUserDto.Password);

            if (!result.Success)
                return BadRequest(new ProblemDetails {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Instance = HttpContext.Request.Path
                });

            return CreatedAtAction(
                actionName: nameof(GetUserById),
                routeValues: new { id = result.User?.Id },
                value: _mapper.Map<UserModel?, UserDto>(result.User));
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
                return BadRequest();

            var result = await _identityService.Login(loginDto.Email, loginDto.Password);

            if (!result.Success)
                return Unauthorized(new ProblemDetails
                {
                    Title = "Houve um erro na requisição.",
                    Detail = result.Message,
                    Status = StatusCodes.Status401Unauthorized,
                    Instance = HttpContext.Request.Path
                });

            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto updateUserDto)
        {
            var user = _mapper.Map<UpdateUserDto, UserModel>(updateUserDto);
            var result = await _userService.UpdateUserAsync(id, user);

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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            
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
