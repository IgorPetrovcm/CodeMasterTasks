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

        await repository.DeleteUser(user1.Id);

        Friend friend1 = await repository.AddFriend(
            new Friend{
                UserFromId = 1,
                UserToId = 2,
                FriendStatus = 1,
                SendDate = new DateTime(2020, 4, 18)
            });
        
        foreach (Friend friend in await repository.GetFriends())
        {
            System.Console.WriteLine($"{friend.Id}, {friend.UserFromId}, {friend.UserToId}, {friend.FriendStatus}, {friend.SendDate}\n");
        }

        await repository.DeleteFriend(friend1.Id);

        Message message1 = await repository.AddMessage(
            new Message{
                AuthorId = repository.AddUser(new User()).Id,
                SendDate = new DateTime(2022, 12, 12),
                Text = "lorem ipsum"
            });

        foreach (Message message in await repository.GetMessages())
        {
            System.Console.WriteLine($"{message.Id}, {message.AuthorId}, {message.SendDate}, \n{message.Text}\n");
        }

        await repository.DeleteMessage(message1.Id);
        await repository.DeleteMessage(message1.AuthorId);

        Message messaage2 = await repository.AddMessage(new Message());

        Like like1 = await repository.AddLike(new Like {
            MessageId = messaage2.Id,
            UserId = repository.AddUser(new User()).Id
        });

        foreach (Like like in await repository.GetLikes())
        {
            System.Console.WriteLine($"{like.Id}, {like.MessageId}, {like.UserId}\n");
        }

        await repository.DeleteLike(like1.Id);
        await repository.DeleteUser(like1.UserId);
        await repository.DeleteMessage(like1.MessageId);
    }
}