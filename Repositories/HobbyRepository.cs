using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;

namespace UserHobbyAPI.Repositories;

public class HobbyRepository : IHobbyRepository
{
    private readonly UserHobbyDbContext _context;

    public HobbyRepository(UserHobbyDbContext context)
    {
        _context = context;
    }
    public async Task<Hobby> Create(HobbyDto dto)
    {
        var newHobby = new Hobby{
            Name = dto.Name,
            Description = dto.Description
        };

        _context.Hobbies.Add(newHobby);
        await _context.SaveChangesAsync();
        return newHobby;
    }

    public Task Delete(Hobby hobby)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Hobby>>? Get()
    {
        return await _context.Hobbies.ToListAsync();
    }

    public async Task<Hobby?> GetById(int id)
    {
        return await _context.Hobbies.FindAsync(id);
    }

    public Task Update(Hobby ushobbyer)
    {
        throw new NotImplementedException();
    }
}