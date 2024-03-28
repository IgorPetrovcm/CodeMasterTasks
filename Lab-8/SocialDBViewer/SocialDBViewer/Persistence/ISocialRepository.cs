namespace SocialDBViewer.Persistence;

using SocialDBViewer.Domain;

public interface ISocialRepository
{
    Task<User> AddUser(User user);
    
    Task<IEnumerable<User>> GetUsers();

    Task DeleteUser(int idUser);

    Task<Friend> AddFriend(Friend friend);

    Task<IEnumerable<Friend>> GetFriends();

    Task DeleteFriend(int friendId);

    Task<Message> AddMessage(Message message);

    Task<IEnumerable<Message>> GetMessages();

    Task DeleteMessage(int messageId);

    Task<Like> AddLike(Like like);

    Task<IEnumerable<Like>> GetLikes();

    Task DeleteLike(int likeId);
}