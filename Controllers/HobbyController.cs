using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;
using UserHobbyAPI.Repositories;

namespace UserHobbyAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class HobbyController : ControllerBase
{
    private readonly IHobbyRepository _hobbyRepository;
    public HobbyController(IHobbyRepository hobbyRepository)
    {
        _hobbyRepository = hobbyRepository;
    }

    [HttpGet(Name = "GetHobbies")]
    public async Task<ActionResult<ICollection<User>>> GetHobbies()
    {
        return Ok(await _hobbyRepository.Get());
    }

    [HttpGet("{id}", Name = "GetHobbiesById")]
    public async Task<ActionResult<Hobby>> GetHobbiesById(int id)
    {
        return Ok(await _hobbyRepository.GetById(id));
    }

    [HttpPost(Name = "CreateHobby")]
    public async Task<ActionResult<Hobby>> CreateUser([FromQuery] HobbyDto dto)
    {
        var result = await _hobbyRepository.Create(dto);

        if(result == null)
        {
            return BadRequest("User or hobby does not exist.");
        }
        return CreatedAtAction(nameof(GetHobbiesById), result.Id, result);
    }
    
}