using System.ComponentModel.DataAnnotations;

namespace Pasajes.Api.Models
{
    public class TaleCreationDto
    {
        [Required(ErrorMessage = "Title must be provided.")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author must be provided.")]
        public string Author { get; set; }

        [Range(-1000, 2000)]
        public int? Year { get; set; }

        [Required(ErrorMessage = "Century must be provided.")]
        [Range(-10, 21)]
        public int Century { get; set; }
    }
}
