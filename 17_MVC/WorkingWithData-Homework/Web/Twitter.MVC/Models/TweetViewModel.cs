namespace Twitter.MVC.Models
{
    using System;
    using System.Collections.Generic;
    using Twitter.Data.Models;
    using Twitter.MVC.Infrastructure;

    public class TweetViewModel : IMapFrom<Tweet>
    {
        public string Content { get; set; }

        public DateTime Created { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}