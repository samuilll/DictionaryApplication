namespace EnglishDictApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Common.Models;
    using EnglishDictApp.Data.Models.Enums;

    public class Word : BaseDeletableModel<int>
    {
        public Word()
        {
            this.WordUsers = new List<UserWord>();
            this.WordSentences = new List<WordSentence>();
            this.Statistics = new List<Statistic>();
        }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Meaning { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech { get; set; }

        [Required]
        public Difficulty WordDifficulty { get; set; }

        [MaxLength(100)]
        public string Transcription { get; set; }

        public virtual IEnumerable<UserWord> WordUsers { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }

        public virtual IEnumerable<WordSentence> WordSentences { get; set; }

    }
}
