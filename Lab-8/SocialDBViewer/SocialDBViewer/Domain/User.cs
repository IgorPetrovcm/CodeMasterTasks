namespace SocialDBViewer.Domain;


public class User
{
    public int User_Id { get; set; }

    public bool Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsOnline { get; set; }

    public string? Name { get; set; }
}