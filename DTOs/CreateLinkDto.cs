namespace UserHobbyAPI.DTOs;

public class CreateLinkDto
{
    public int UserId { get; set; }
    public int HobbyId { get; set; }
    public string? Url { get; set; }

}