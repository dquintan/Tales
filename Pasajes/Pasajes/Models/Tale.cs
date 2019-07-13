using System;
using System.Collections.Generic;
using System.Text;

namespace Pasajes.Models
{
    public class Tale
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public int Century { get; set; }
    }
}
