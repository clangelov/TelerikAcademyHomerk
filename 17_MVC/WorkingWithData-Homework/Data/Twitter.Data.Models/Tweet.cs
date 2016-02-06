namespace Twitter.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tweet
    {
        public ICollection<Tag> tags;

        public Tweet()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }
    }
}
