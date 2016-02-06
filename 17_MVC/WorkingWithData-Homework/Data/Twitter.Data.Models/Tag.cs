namespace Twitter.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public int TweetId { get; set; }

        public virtual Tweet Tweets { get; set; }
    }
}
