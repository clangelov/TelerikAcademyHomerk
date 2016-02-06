namespace Twitter.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Twitter.Data.Models;
    using Twitter.Data.Repositories;
    using Twitter.Services.Data.Contracts;

    public class TweetService : ITweetService
    {
        private readonly IRepository<Tweet> tweets;

        private readonly IRepository<User> users;

        public TweetService(IRepository<Tweet> tweets, IRepository<User> users)
        {
            this.tweets = tweets;
            this.users = users;
        }

        public IQueryable<Tweet> ByTag(string tag)
        {
            return this.tweets.All().Where(t => t.Tags.All(x => x.Name.Contains(tag)));
        }

        public IQueryable<Tweet> ByUser(string userName)
        {
            return this.tweets.All().Where(t => t.User.UserName == userName);
        }

        public Tweet CrateTag(string userName, string comment, List<string> tags)
        {
            var user = this.users.All().Where(x => x.UserName == userName).FirstOrDefault();
            var tagsToAdd = new List<Tag>();
            foreach (var item in tags)
            {
                var tagToAdd = new Tag { Name = item };
                tagsToAdd.Add(tagToAdd);
            }

            var tweetToAdd = new Tweet
            {
                UserId = user.Id,
                Content = comment,
                Created = DateTime.UtcNow,
                Tags = tagsToAdd
            };            

            this.tweets.Add(tweetToAdd);
            this.tweets.SaveChanges();

            return tweetToAdd;
        }

        public IQueryable<Tweet> LastTen()
        {
            return this.tweets.All().OrderByDescending(x => x.Created).Take(10);
        }
    }
}
