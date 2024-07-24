using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
using weddingApp.Model.DTO_s;
using weddingApp.Model.Entities;
using weddingApp.Services.Interfaces;
using weddingApp.Services.Security;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public AuthController(IJwtService jwtService, IUserService userService,IMapper mapper)
    {
        _jwtService = jwtService;
        _userService = userService;
        _mapper = mapper;
    }
    //TODO dodanie register i login DTO
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDto registerDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        User? existingUser = await _userService.Authenticate(registerDto.Email, registerDto.Password);
        if (existingUser != null)
            return Conflict("Username is already taken");

        User? user = _mapper.Map<User>(registerDto);
        User? createdUser = await _userService.CreateUserAsync(user);

        UserDto? userDto = _mapper.Map<UserDto>(createdUser);
        string? token = _jwtService.GenerateToken(createdUser);

        return CreatedAtAction(nameof(Register), new { username = userDto.Email }, new { Token = token, User = userDto });
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserDto loginDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        User? user = await _userService.Authenticate(loginDto.Email, loginDto.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        string? token = _jwtService.GenerateToken(user);
        UserDto? userDto = _mapper.Map<UserDto>(user);

        return Ok(new { Token = token, User = userDto });
    }
  
}
