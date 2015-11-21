namespace BugLogger.Api.Models
{
    using System.ComponentModel.DataAnnotations;

    public class SaveBugModel
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}