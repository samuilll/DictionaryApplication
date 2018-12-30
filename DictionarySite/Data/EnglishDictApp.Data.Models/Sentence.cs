namespace EnglishDictApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Common.Models;

    public class Sentence : BaseDeletableModel<int>
    {
        public Sentence()
        {
            this.SentenceWords = new List<WordSentence>();
        }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength =1)]
        public string Content { get; set; }

        public virtual IEnumerable<WordSentence> SentenceWords { get; set; }
    }
}
