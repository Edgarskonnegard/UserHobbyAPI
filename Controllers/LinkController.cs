using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;
using UserHobbyAPI.Repositories;

namespace UserHobbyAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LinkController : ControllerBase
{
    private readonly ILinkRepository _linkRepository;
    public LinkController(ILinkRepository linkRepository)
    {
        _linkRepository = linkRepository;
    }

    [HttpGet("{id}", Name = "GetById")]
    public async Task<ActionResult<Link?>> GetById(int id)
    {
        var link = await _linkRepository.GetById(id);
        if (link == null)
            return NotFound();

        return Ok(link);
    }

    [HttpPost(Name = "CreateLink")]
    public async Task<ActionResult<Link>> CreateLink([FromQuery] CreateLinkDto dto)
    {
        var result = await _linkRepository.Create(dto);

        if(result == null)
        {
            return BadRequest("User or hobby does not exist.");
        }
        return CreatedAtAction(nameof(GetById), result.Id, result);
    }
}