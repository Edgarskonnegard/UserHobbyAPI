using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;
using UserHobbyAPI.Repositories;

namespace UserHobbyAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet(Name = "GetUsers")]
    public async Task<ActionResult<ICollection<User>>> GetUsers()
    {
        return Ok(await _userRepository.Get());
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        return Ok(await _userRepository.GetById(id));
    }

    [HttpPost(Name = "CreateUser")]
    public async Task<ActionResult<User>> CreateUser([FromQuery] UserDto dto)
    {
        var result = await _userRepository.Create(dto);

        if(result == null)
        {
            return BadRequest("User or hobby does not exist.");
        }
        return CreatedAtAction(nameof(GetUserById), new {Id = result.Id}, result);
    }
}