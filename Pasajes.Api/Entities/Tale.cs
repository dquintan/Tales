using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pasajes.Api.Entities
{
    public class Tale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Author { get; set; }

        [Range(-1000, 2000)]
        public int? Year { get; set; }

        [Range(-10, 21)]
        public int Century { get; set; }


        public ICollection<TaleSource> TaleSources { get; set; } = new List<TaleSource>();

        public ICollection<TaleLocation> TaleLocations { get; set; } = new List<TaleLocation>();

    }
}
