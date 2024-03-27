namespace SocialDBViewer.Persistence;

using SocialDBViewer.Domain;

public interface ISocialRepository
{
    Task<User> AddUser(User user);
}