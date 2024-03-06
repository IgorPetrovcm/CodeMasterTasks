namespace Social.DataGenerator;

using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text.Json;
using Faker;

public class Program 
{
    const string PathWithUsers = "../Social/Data/users.json";
    const string PathWithFriends = "../Social/Data/friends.json";
    const string PathWithMessages = "../Social/Data/messages.json";

    static void Main()
    {
        Random rnd = new Random();

        DateTime startDate = new DateTime(2000,1,1);

        using (FileStream fs = new FileStream(PathWithUsers, FileMode.Open, FileAccess.ReadWrite))
        {
            List<User> users = JsonSerializer.Deserialize <List<User>> (fs);

            for (int i = 6; i < 107; i++)
            {
                User user = new User()
                {
                    Name = Faker.Name.FullName() + i,
                    Gender = Faker.RandomNumber.Next(0,1),
                    LastVisit = DateTime.Now.AddDays(rnd.Next(120)),
                    DateOfBirth = startDate.AddDays(rnd.Next(366)),
                    Online = Faker.Boolean.Random(),
                    UserId = i 
                };
                
                users.Add(user);
            }

            fs.SetLength(0);

            JsonSerializer.Serialize <List<User>> (fs, users);
        }

        using (FileStream fs = new FileStream(PathWithFriends, FileMode.Open, FileAccess.ReadWrite))
        {
            List<Friend> friends = JsonSerializer.Deserialize <List<Friend>> (fs);

            for (int i = 0; i < 1000; i++)
            {
                Friend friend = new Friend()
                {
                    FromUserId = rnd.Next(1,106),
                    SendDate = startDate.AddDays(rnd.Next(366)),
                    Status = rnd.Next(0,3),
                    ToUserId = rnd.Next(1, 106)
                };

                friends.Add(friend);
            }

            fs.SetLength(0);

            JsonSerializer.Serialize <List<Friend>> (fs, friends);
        }

        using (FileStream fs = new FileStream(PathWithMessages, FileMode.Open, FileAccess.ReadWrite))
        {
            List<Message> messages = JsonSerializer.Deserialize <List<Message>> (fs);

            for (int i = 6; i < 207; i++)
            {
                List<int> likes = new List<int>();

                int countLikes = rnd.Next(0,10);

                for (int j = 0; j < countLikes; j++)
                {
                    likes.Add(rnd.Next(1,106));
                }

                Message message = new Message()
                {
                    AuthorId = rnd.Next(1, 106),
                    Likes = likes,
                    SendDate = DateTime.Now.AddDays(rnd.Next(120)),
                    Text = Faker.Lorem.Words(1).ToArray()[0],
                    MessageId = i
                };

                messages.Add(message);
            }

            fs.SetLength(0);

            JsonSerializer.Serialize <List<Message>> (fs, messages);
        }
    }
}
