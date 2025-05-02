using UserHobbyAPI.Models;
using UserHobbyAPI.DTOs;

namespace UserHobbyAPI.Repositories;

public interface ILinkRepository
{
    public Task<Link?> GetById(int id);
    public Task<ICollection<Link>?> GetByUserId(int id);
    public Task<ICollection<Link>?> GetByHobbyId(int id);
    public Task<Link?> Create(CreateLinkDto dto);
    public Task Update(UserHobby userhobby);
    public Task Delete(UserHobby userHobby);

}