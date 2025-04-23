using System.ComponentModel.DataAnnotations;

namespace UserHobbyApi.Models;

public class UserHobby
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int HobbyId { get; set; }
    public Hobby Hobby { get; set; }

    public string Url { get; set;} = string.Empty;

}