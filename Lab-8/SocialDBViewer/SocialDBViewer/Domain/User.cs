namespace SocialDBViewer.Domain;


public class User
{
    public int Id { get; set; }

    public bool Gender { get; set; } = false;

    public DateTime DateOfBirth { get; set; } = new DateTime(1999, 9, 9);

    public bool IsOnline { get; set; } = false;

    public string Name { get; set; } = "defaultName";
}