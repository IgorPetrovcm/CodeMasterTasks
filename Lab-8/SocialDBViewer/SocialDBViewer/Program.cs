namespace SocialDBViewer;

using SocialDBViewer.Domain;
using SocialDBViewer.Persistence;
using Microsoft.Extensions.Configuration;

public class Program
{
    static async Task Main()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .Build();

        string? connectionString = configuration.GetConnectionString("DefaultConnectionString");

        SocialRepository repository = new SocialRepository(connectionString ?? string.Empty);

        User user1 = await repository.AddUser( 
            new User
            {
                Name = "test1",
                IsOnline = true,
                Gender = true,
                DateOfBirth = new DateTime(2009, 8, 12)
            });

        foreach (User user in await repository.GetUsers())
        {
            System.Console.WriteLine($"{user.Id}, {user.Name}, {user.IsOnline}, {user.DateOfBirth}, {user.Gender}\n");
        }

        User userForFriend1 = await repository.AddUser(new User());
        User userForFriend2 = await repository.AddUser(new User());
        

        Friend friend1 = await repository.AddFriend(
            new Friend{
                UserFromId = userForFriend1.Id,
                UserToId = userForFriend2.Id,
                FriendStatus = 1,
                SendDate = new DateTime(2020, 4, 18)
            });
        
        foreach (Friend friend in await repository.GetFriends())
        {
            System.Console.WriteLine($"{friend.Id}, {friend.UserFromId}, {friend.UserToId}, {friend.FriendStatus}, {friend.SendDate}\n");
        }

        await repository.DeleteFriend(friend1.Id);
        await repository.DeleteUser(userForFriend1.Id);
        await repository.DeleteUser(userForFriend2.Id);

        User userForMessage = await repository.AddUser(new User());

        Message message1 = await repository.AddMessage(
            new Message{
                AuthorId = userForMessage.Id,
                SendDate = new DateTime(2022, 12, 12),
                Text = "lorem ipsum"
            });

        foreach (Message message in await repository.GetMessages())
        {
            System.Console.WriteLine($"{message.Id}, {message.AuthorId}, {message.SendDate}, \n{message.Text}\n");
        }

        await repository.DeleteMessage(message1.Id);
        await repository.DeleteUser(userForMessage.Id);

        Message message2 = await repository.AddMessage(new Message { AuthorId = user1.Id });
        User userForLike = await repository.AddUser(new User());

        Like like1 = await repository.AddLike(new Like {
            MessageId = message2.Id,
            UserId = userForLike.Id
        });

        foreach (Like like in await repository.GetLikes())
        {
            System.Console.WriteLine($"{like.Id}, {like.MessageId}, {like.UserId}\n");
        }

        await repository.DeleteLike(like1.Id);
        await repository.DeleteUser(userForLike.Id);
        await repository.DeleteMessage(message2.Id);
    }
}