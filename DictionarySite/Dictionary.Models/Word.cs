using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dictionary.Models
{
    public class Word
    {
        public Word()
        {
            this.WordUsers = new HashSet<UserWord>();
        }
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Meaning { get; set; }

        public IEnumerable<UserWord> WordUsers { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }
    }
}
