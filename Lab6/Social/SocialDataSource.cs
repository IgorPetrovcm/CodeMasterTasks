namespace Social
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using Social.Models;

    public class SocialDataSource
    {
        private List<User> _users;

        private List<Friend> _friends;

        private List<Message> _messages;

        public SocialDataSource(string pathUsers, string pathFriends, string pathMessages)
        {
            GetUsers(pathUsers);
            GetFriends(pathFriends);
            GetMessages(pathMessages);
        }

        public UserContext GetUserContext(string userName)
        {
            UserContext userContext = new UserContext();

            userContext.User = _users.Find(x => x.Name == userName);

            userContext.Friends = _friends
                .Where(x => (x.FromUserId == userContext.User.UserId || x.ToUserId == userContext.User.UserId) && x.Status == 2)
                .Join(_users, 
                    f => { 
                        if (f.FromUserId == userContext.User.UserId) 
                            return f.ToUserId; 
                        else 
                            return f.FromUserId;
                    },
                    u => u.UserId,
                    (f, u) => new UserInformation { UserId = u.UserId, Name = u.Name, Online = u.Online })
                .ToList();


            userContext.OnlineFriends = userContext.Friends.Where(x => x.Online).ToList();

            userContext.FriendshipOffers = _friends
                .Where(x => x.ToUserId == userContext.User.UserId && x.Status != 2 && x.Status != 3 && x.SendDate > userContext.User.LastVisit)
                .Join(_users,
                    f => {
                        if (f.FromUserId == userContext.User.UserId)
                            return f.ToUserId;
                        else
                            return f.FromUserId;
                    },
                    u => u.UserId,
                    (f, u) => new UserInformation { UserId = u.UserId, Name = u.Name, Online = u.Online})
                .ToList();

            userContext.Subscribers = _friends
                .Where(x => x.ToUserId == userContext.User.UserId && x.Status != 2)
                .Join(_users,
                    f => f.FromUserId,
                    u => u.UserId,
                    (f, u) => new UserInformation { UserId = u.UserId, Name = u.Name, Online = u.Online})
                .ToList();

            userContext.News = _messages
                .Where(x => userContext.Friends.Any(f => f.UserId == x.AuthorId) && x.SendDate > userContext.User.LastVisit)
                .Join(_users,
                    m => m.AuthorId,
                    u => u.UserId,
                    (f, u) => new News { AuthorId = f.AuthorId, AuthorName = u.Name, Likes = f.Likes, Text = f.Text} )
                .ToList();


            return userContext;
        }

        public User GetUserById(int id)
        {
            return _users.Find(x => x.UserId == id);
        }

        private void GetUsers(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            _users = JsonSerializer.Deserialize<List<User>>(fs);

            fs.Dispose();
        }

        private void GetFriends(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            _friends = JsonSerializer.Deserialize<List<Friend>>(fs);

            fs.Dispose();
        }

        private void GetMessages(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

            _messages = JsonSerializer.Deserialize<List<Message>>(fs);

            fs.Dispose();
        }
    }
}
