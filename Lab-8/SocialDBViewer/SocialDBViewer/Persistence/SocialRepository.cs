namespace SocialDBViewer.Persistence;

using SocialDBViewer.Domain;
using Dapper;
using Npgsql;
using System.Runtime.CompilerServices;

public class SocialRepository : ISocialRepository
{
    private readonly string _connectionString;

    public SocialRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = "select user_id as Id, name as Name, is_online as IsOnline, date_of_birth as DateOfBirth, gender as Gender from users";

            return await connection.QueryAsync<User>(query);
        }
    }

    public async Task<User> AddUser(User user)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync()) 
        {
            string query = $"insert into users (name, is_online, date_of_birth, gender) " +
                            $"values (@{nameof(User.Name)}, @{nameof(User.IsOnline)}, @{nameof(User.DateOfBirth)}, @{nameof(User.Gender)})";
            await connection.ExecuteAsync(query, user);
            
            string idLastUserQuery = "select user_id from users order by user_id desc limit 1";

            List<int> idLastUser = (await connection.QueryAsync<int>(idLastUserQuery)).ToList();

            return new User { Id = idLastUser.First(), DateOfBirth = user.DateOfBirth, Gender = user.Gender, IsOnline = user.IsOnline};
        }
    }

    public async Task DeleteUser(int userId)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"delete from users where user_id = @UserId";
            
            await connection.ExecuteAsync(query, new {UserId = userId});
        }
    }

    public async Task<IEnumerable<Friend>> GetFriends()
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = "select friend_id as Id, user_from as UserFromId, user_to as UserToId, friend_status as FriendStatus, send_date as SendDate " +
                            "from friends";

            return await connection.QueryAsync<Friend>(query);
        }

    }

    public async Task<Friend> AddFriend(Friend friend)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"insert into friends (user_from, user_to, friend_status, send_date) " +
                            $"values (@{nameof(Friend.UserFromId)}, @{nameof(Friend.UserToId)}, @{nameof(Friend.FriendStatus)}, @{nameof(Friend.SendDate)})";
            
            await connection.ExecuteAsync(query, friend);

            string idLastFriendQuery = "select friend_id from friends order by friend_id desc limit 1";

            List<int> idLastFriend = (await connection.QueryAsync<int>(idLastFriendQuery)).ToList();

            return new Friend {
                Id = idLastFriend.First(),
                UserFromId = friend.UserFromId,
                UserToId = friend.UserToId,
                FriendStatus = friend.FriendStatus,
                SendDate = friend.SendDate
            };
        }
    }

    public async Task DeleteFriend(int friendId)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"delete from friends where friend_id = @FriendId";
            
            await connection.ExecuteAsync(query, new {FriendId = friendId});
        }
    }

    public async Task<IEnumerable<Message>> GetMessages()
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = "select message_id as Id, author_id as AuthorId, send_date as SendDate, message_text as Text " +
                            "from messages";

            return await connection.QueryAsync<Message>(query);
        }
    }

    public async Task<Message> AddMessage(Message message)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"insert into messages (author_id, send_date, message_text) " +
                            $"values (@{nameof(Message.AuthorId)}, @{nameof(Message.SendDate)}, @{nameof(Message.Text)} )";
            
            await connection.ExecuteAsync(query, message);

            string idLastMessageQuery = "select message_id from messages order by message_id desc limit 1";

            List<int> idLastMessage = (await connection.QueryAsync<int>(idLastMessageQuery)).ToList();

            return new Message {
                Id = idLastMessage.First(),
                AuthorId = message.AuthorId,
                SendDate = message.SendDate,
                Text = message.Text
            };
        }
    }

    public async Task DeleteMessage(int messageId)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"delete from messages where message_id = @MessageId";
            
            await connection.ExecuteAsync(query, new {MessageId = messageId});
        }
    }

    public async Task<IEnumerable<Like>> GetLikes()
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = "select like_id as Id, user_id as UserId, message_id as MessageId " +
                            "from likes";

            return await connection.QueryAsync<Like>(query);
        }
    }

    public async Task<Like> AddLike(Like like)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"insert into likes (user_id, message_id) " +
                            $"values (@{nameof(Like.UserId)}, @{nameof(Like.MessageId)})";
            
            await connection.ExecuteAsync(query, like);

            string idLastLikeQuery = "select like_id from likes order by message_id desc limit 1";

            List<int> idLastLike = (await connection.QueryAsync<int>(idLastLikeQuery)).ToList();

            return new Like {
                Id = idLastLike.First(),
                UserId = like.UserId,
                MessageId = like.MessageId
            };
        }
    }  

    public async Task DeleteLike(int likeId)
    {
        NpgsqlDataSource dataSource = new NpgsqlDataSourceBuilder(_connectionString).Build();

        await using (NpgsqlConnection connection = await dataSource.OpenConnectionAsync())
        {
            string query = $"delete from likes where friend_id = @LikeId";
            
            await connection.ExecuteAsync(query, new {LikeId = likeId});
        }
    }
}