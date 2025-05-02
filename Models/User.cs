using System.ComponentModel.DataAnnotations;

namespace UserHobbyAPI.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set;} = string.Empty;
    public string LastName { get; set;} = string.Empty;
    public int BirthYear { get; set;}

    public string PhoneNumber { get; set;} = string.Empty;
    public ICollection<UserHobby> UserHobbies { get; set;}

}