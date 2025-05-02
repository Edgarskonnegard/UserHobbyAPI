using UserHobbyAPI.Models;
using UserHobbyAPI.DTOs;

namespace UserHobbyAPI.Repositories;

public interface IUserHobbyRepository
{
    public Task<ICollection<UserHobby>>? Get();
    public Task<ICollection<Hobby>?> GetByUserId(int id);
    public Task<ICollection<User>?> GetByHobbyId(int id);
    public Task<ICollection<LinksDto>?> GetLinksByUserId(int id);
    public Task<UserHobby?> Create(CreateUserHobbyDto dto);
    public Task Update(UserHobby userhobby);
    public Task Delete(UserHobby userHobby);

}