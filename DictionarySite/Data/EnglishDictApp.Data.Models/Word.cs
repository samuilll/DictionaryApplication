﻿namespace EnglishDictApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Common.Models;

    public class Word : BaseDeletableModel<int>
    {
        public Word()
        {
            this.WordUsers = new HashSet<UserWord>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string Meaning { get; set; }

        public IEnumerable<UserWord> WordUsers { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech { get; set; }
    }
}