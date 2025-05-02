using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;

namespace UserHobbyAPI.Repositories;

public class LinkRepository : ILinkRepository
{
    private readonly UserHobbyDbContext _context;

    public LinkRepository(UserHobbyDbContext context)
    {
        _context = context;
    }
    public async Task<Link?> Create(CreateLinkDto dto)
    {
        var userHobbyToUpdate = await _context.UserHobbies
        .FirstOrDefaultAsync(uh => uh.UserId == dto.UserId && uh.HobbyId == dto.HobbyId);
        
        if (userHobbyToUpdate == null)
        {
            return null;
        }

        var link = new Link{
            Url = dto.Url
        };

        userHobbyToUpdate.Links.Add(link);
        await _context.SaveChangesAsync();

        return link;
    }

    public Task Delete(UserHobby userHobby)
    {
        throw new NotImplementedException();
    }

    public async Task<Link?> GetById(int id)
    {
        return await _context.Links.FindAsync(id);
    }

    public Task<ICollection<Link>?> GetByHobbyId(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Link>?> GetByUserId(int id)
    {
        throw new NotImplementedException();
    }

    public Task Update(UserHobby userhobby)
    {
        throw new NotImplementedException();
    }
}