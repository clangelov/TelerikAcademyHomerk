using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Data.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(1, 150)]
        public int Age { get; set; }

        public string Studio { get; set; }

        public string StudioAdress { get; set; }
    }
}
