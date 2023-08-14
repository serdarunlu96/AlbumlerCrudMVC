using System.ComponentModel.DataAnnotations;

namespace Albums.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Artist { get; set; }

        public int Year { get; set; }
    }
}
