using System;
using System.Collections.Generic;

namespace TestPro.Models
{
    public partial class Words
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Meaning { get; set; }
        public string Example { get; set; }
        public string Synonyms { get; set; }
    }
}
