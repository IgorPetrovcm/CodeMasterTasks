namespace SocialDBViewer.Persistence;

using SocialDBViewer.Domain;
using Dapper;

public class SocialRepository : ISocialRepository
{
    private readonly string _connectionString;

    public SocialRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Task<User> AddUser(User user)
    {


        throw new NotImplementedException();
    }
}