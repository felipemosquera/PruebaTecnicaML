using System;
using System.Collections.Generic;

#nullable disable

namespace Felipe_ML.Models
{
    public partial class Dna
    {
        public string DnaSequence { get; set; }
        public bool? IsHuman { get; set; }
        public bool? IsMutant { get; set; }
    }
}
