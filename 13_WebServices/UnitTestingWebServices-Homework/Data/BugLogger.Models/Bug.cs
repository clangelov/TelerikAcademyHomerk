namespace BugLogger.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Bug
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Text { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/2015", "31/12/2050")]
        public DateTime Logged { get; set; }

        public BugStatus BugStatus { get; set; }
    }
}
