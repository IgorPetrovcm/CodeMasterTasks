namespace SocialDBViewer.Domain;


public class Friend 
{
    public int Id { get; set; }

    public int UserFromId { get; set; }

    public int UserToId { get; set; }

    public int FriendStatus { get; set; }

    public DateTime SendDate { get; set; }
}