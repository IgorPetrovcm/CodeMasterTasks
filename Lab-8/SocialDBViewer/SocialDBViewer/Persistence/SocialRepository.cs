namespace SocialDBViewer.Persistence;

using SocialDBViewer.Domain;
using Dapper;
using Npgsql;

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

            return connection.Query<User>(query);
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
}