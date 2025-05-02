namespace UserHobbyAPI.Models;

public class Link
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;

    public int UserHobbyId { get; set; }
    public UserHobby UserHobby { get; set; }
}