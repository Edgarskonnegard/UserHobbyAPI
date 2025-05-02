using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;

namespace UserHobbyAPI.Repositories;

public interface IUserRepository
{
    public Task<ICollection<User>>? Get();
    public Task<User?> GetById(int id);
    public Task<User> Create(UserDto dto);
    public Task Update(User user);
    public Task Delete(User user);

}