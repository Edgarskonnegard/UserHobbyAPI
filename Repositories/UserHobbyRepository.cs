using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.Models;
using UserHobbyAPI.DTOs;

namespace UserHobbyAPI.Repositories;

public class UserHobbyRepository : IUserHobbyRepository
{
    private readonly UserHobbyDbContext _context;

    public UserHobbyRepository(UserHobbyDbContext context)
    {
        _context = context;
    }
    public async Task<UserHobby?> Create([FromQuery] CreateUserHobbyDto dto)
    {
        var userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
        if(!userExists)
        {
            return null;
        }
        var hobbyExists = await _context.Hobbies.AnyAsync(h => h.Id == dto.HobbyId);
        if(!hobbyExists)
        {
            return null;
        }

        var createUserHobby = new UserHobby{
            UserId = dto.UserId,
            HobbyId = dto.HobbyId
        };
        _context.Add(createUserHobby);
        await _context.SaveChangesAsync();

        return createUserHobby;
    }

    public Task Delete(UserHobby userHobby)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<UserHobby>>? Get()
    {
        return await _context.UserHobbies.ToListAsync();
    }

    public async Task<ICollection<Hobby>?> GetByUserId(int id)
    {
        var hobbies = await _context.UserHobbies.Where(uh => uh.UserId == id).Select(uh => uh.Hobby).ToListAsync();
        return hobbies;
    }

    public async Task<ICollection<User>?> GetByHobbyId(int id)
    {
        var users = await _context.UserHobbies.Where(uh => uh.HobbyId == id).Select(uh => uh.User).ToListAsync();
        return users;
    }

    public async Task<ICollection<LinksDto>?> GetLinksByUserId(int id)
    {
        var links = await _context.UserHobbies
        .Where(uh => uh.UserId == id)
        .SelectMany(uh => uh.Links)
        .Select(l => new LinksDto{
            UserName = l.UserHobby.User.FirstName + " " + l.UserHobby.User.LastName,
            HobbyName = l.UserHobby.Hobby.Name,
            Link = l.Url
        })
        .ToListAsync();

        return links;
    }

    public Task Update(UserHobby userHobby)
    {
        throw new NotImplementedException();
    }
}