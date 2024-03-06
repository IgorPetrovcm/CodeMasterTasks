namespace Social
{
    using System;
    using System.Collections.Generic;
    using Social.Models;

    internal class Program
    {
        // TODO: пути к файлам
        private const string PathDirectory = "Data";
        private const string PathUsers = PathDirectory + "/users.json";
        private const string PathFriends = PathDirectory + "/friends.json";
        private const string PathMessages = PathDirectory + "/messages.json";

        private static void Main(string[] args)
        {
            string name;

            if (args.Length == 0)
            {
                System.Console.WriteLine("Input user name please: ");
                name = Console.ReadLine();
            }
            else 
            {
                name = args[0];
            }

            SocialDataSource social = new SocialDataSource(PathUsers, PathFriends, PathMessages);

            UserContext userContext = social.GetUserContext(name); 

            string userGender = userContext.User.Gender == 0 ? "Male" : "Female";

            System.Console.WriteLine("User Info: ");

            System.Console.WriteLine("\tName: " + userContext.User.Name + "\n\tGender: " + userGender + "\n\tOnline: " + userContext.User.Online);

            GoInfo(x => x.Friends, userContext, "Friends: ");
            GoInfo(x => x.OnlineFriends, userContext, "Friends online: ");
            GoInfo(x => x.FriendshipOffers, userContext, "Friendship offers: ");
            GoInfo(x => x.Subscribers, userContext, "Subscribers: ");

            System.Console.WriteLine("News: ");

            foreach (News news in userContext.News)
            {
                System.Console.WriteLine("\t" + news.AuthorName + "\n\tLikes: " + news.Likes.Count + "\n\t" + news.Text + "\n");
            }
        }

        public static void GoInfo(Func<UserContext, List<UserInformation>> func, UserContext context, string title)
        {
            System.Console.WriteLine(title);

            foreach (UserInformation user in func(context))
            {
                System.Console.WriteLine("\t" + user.Name);
            }
        }
    }
}
