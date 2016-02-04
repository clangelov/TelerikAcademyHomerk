namespace Movies.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [Range(1900, 2050)]
        public int Year { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Director { get; set; }

        public int? MaleActorId { get; set; }

        public Actor MaleActor { get; set; }

        public int? FemaleActorId { get; set; }

        public Actor FemaleActor { get; set; }
    }
}
