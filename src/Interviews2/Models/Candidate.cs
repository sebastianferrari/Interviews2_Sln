using System.ComponentModel.DataAnnotations;

namespace Interviews2.Models
{
    public class Candidate
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Full name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email address")]
        public string EMail { get; set; }
    }
}