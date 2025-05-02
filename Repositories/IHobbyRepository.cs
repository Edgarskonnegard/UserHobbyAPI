using UserHobbyAPI.DTOs;
using UserHobbyAPI.Models;

namespace UserHobbyAPI.Repositories;

public interface IHobbyRepository
{
    public Task<ICollection<Hobby>>? Get();
    public Task<Hobby?> GetById(int id);
    public Task<Hobby> Create(HobbyDto dto);
    public Task Update(Hobby hobby);
    public Task Delete(Hobby hobby);

}