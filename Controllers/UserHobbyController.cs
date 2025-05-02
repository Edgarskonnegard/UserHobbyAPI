using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.Models;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Repositories;

namespace UserHobbyAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserHobbyController : ControllerBase
{
    private readonly IUserHobbyRepository _userHobbyRepository;
    public UserHobbyController(IUserHobbyRepository userHobbyRepository)
    {
        _userHobbyRepository = userHobbyRepository;
    }

    [HttpGet(Name = "Get")]
    public async Task<ActionResult<ICollection<UserHobby>>?> Get()
    {
        return Ok(await _userHobbyRepository.Get());
    }

    [HttpGet("{id}/User", Name = "GetHobbiesByUserId")]
    public async Task<ActionResult<ICollection<UserHobby>>> GetHobbiesByUserId(int id)
    {
        return Ok(await _userHobbyRepository.GetByUserId(id));
    }

    [HttpGet("{id}/Hobby", Name = "GetUsersByHobbyId")]
    public async Task<ActionResult<UserHobby>> GetUsersByHobbyId(int id)
    {
        return Ok(await _userHobbyRepository.GetByHobbyId(id));
    }

    [HttpGet("{id}/User/Link", Name = "GetLinksByUserId")]
    public async Task<ActionResult<ICollection<LinksDto>?>> GetLinksByUserId(int id)
    {
        return Ok(await _userHobbyRepository.GetLinksByUserId(id));
    }

    [HttpPost(Name = "CreateUserHobbyById")]
    public async Task<ActionResult<UserHobby>?> CreateUserHobbyById([FromQuery] CreateUserHobbyDto dto)
    {
        var result = await _userHobbyRepository.Create(dto);

        if(result == null)
        {
            return BadRequest("User or hobby does not exist.");
        }
        return CreatedAtAction(nameof(Get), result, dto);
    }
}