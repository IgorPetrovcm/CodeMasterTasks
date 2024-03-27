namespace SocialDBViewer.Domain;


public class Message 
{
    public int MessageId { get; set; }

    public int AuthorId { get; set; }

    public DateTime SendDate { get; set; }

    public string? Text { get; set; }
}