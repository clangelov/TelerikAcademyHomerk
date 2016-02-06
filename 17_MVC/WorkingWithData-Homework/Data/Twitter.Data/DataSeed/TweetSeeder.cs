namespace Twitter.Data.DataSeed
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Data.Models;

    public class TweetSeeder : IDataSeeder
    {
        public static Random Rand = new Random();

        public void Seed(TwitterDbContext context)
        {
            const string autor = "student@gmail.com";

            var isAutorSeeded = context.Users.Any(u => u.UserName == autor);

            if (!isAutorSeeded)
            {
                var userManager = new UserManager<User>(new UserStore<User>(context));

                var someAuthor = new User() { UserName = autor, Email = autor };

                userManager.Create(someAuthor, "123456");

                for (int i = 0; i < 5; i++)
                {
                    var newTweet = new Tweet()
                    {
                        Content = "Some Tweet " + i,
                        UserId = someAuthor.Id,
                        Created = DateTime.Now.AddDays(Rand.Next(-10, 0)),
                        tags = new List<Tag>() { new Tag() { Name = "Tag" + i } }
                    };

                    context.Tweets.Add(newTweet);
                }

                context.SaveChanges();
            }
        }
    }
}
