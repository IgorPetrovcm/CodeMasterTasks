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
            if (args.Length == 0)
            {
                Console.WriteLine("Имя пользователя не задано!");
                return;
            }

            var name = args[0];

            if (string.IsNullOrEmpty(name))
            {
                // TODO
                return;
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

            /*var socialDataSource = new SocialDataSource(PathUsers, PathFriends, PathMessages);

            var userContext = socialDataSource.GetUserContext(name);*/

            // todo: вывод в консоль
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
