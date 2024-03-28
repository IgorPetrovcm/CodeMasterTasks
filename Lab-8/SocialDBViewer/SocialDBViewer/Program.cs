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
            System.Console.WriteLine($"{user.Id}, {user.Name}, {user.IsOnline}, {user.DateOfBirth}, {user.Gender}");
        }
    }
}