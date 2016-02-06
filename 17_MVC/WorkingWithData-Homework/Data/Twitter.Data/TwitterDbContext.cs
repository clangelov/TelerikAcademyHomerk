namespace Twitter.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Twitter.Data.Models;

    public class TwitterDbContext : IdentityDbContext<User>, ITwitterDbContext
    {
        public TwitterDbContext()
           : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }


        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }
    }
}
