using Microsoft.EntityFrameworkCore;
using UserHobbyAPI.Data;
using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;

namespace UserHobbyAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly UserHobbyDbContext _context;

    public UserRepository(UserHobbyDbContext context)
    {
        _context = context;
    }

    public async Task<User> Create(UserDto dto)
    {
        var newUser = new User{
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            BirthYear = dto.BirthYear,
            PhoneNumber = dto.PhoneNumber
        };

        _context.Users.Add(newUser);
        await _context.SaveChangesAsync();
        return newUser;
    }

    public Task Delete(User user)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public Task Update(User user)
    {
        throw new NotImplementedException();
    }
}