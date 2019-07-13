using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasajes.Api.Entities
{
    public class TaleSource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Url { get; set; }

        public int? Priority { get; set; }

        [ForeignKey("TaleId")]
        public Tale Tale { get; set; }
        public Guid TaleId { get; set; }

    }
}
