using System.ComponentModel.DataAnnotations;

namespace UserHobbyAPI.Models;

public class UserHobby
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int HobbyId { get; set; }
    public Hobby Hobby { get; set; }

    public ICollection<Link> Links { get; set;} = new List<Link>();

}