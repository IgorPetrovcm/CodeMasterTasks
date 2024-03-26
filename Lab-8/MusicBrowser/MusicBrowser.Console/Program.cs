namespace MusicBrowser.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using MusicBrowser.Console.Application;
    using MusicBrowser.Console.DataAccess;
    using MusicBrowser.Console.DataAccess.AdoNet;
    using MusicBrowser.Console.Domain;

    internal class Program
    {
        public static async Task Main()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();

            string connectionString = config.GetConnectionString("DefaultConnectionString");

            IMusicRepository musicRepository = new SingleQueryAdoNetRepository(connectionString);

            var dataModel = new MusicListModel(musicRepository);
            var list = new ExpandableList(dataModel);

            list.Run();
        }
    }
}
