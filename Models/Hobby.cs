using System.ComponentModel.DataAnnotations;

namespace UserHobbyAPI.Models;

public class Hobby
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [MaxLength(500)]
    public string? Description { get; set; }
    public ICollection<UserHobby> UserHobbies { get; set; }

}
