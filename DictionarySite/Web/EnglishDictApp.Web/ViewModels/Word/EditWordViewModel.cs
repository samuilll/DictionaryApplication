namespace EnglishDictApp.Web.ViewModels.Word
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Data.Models.Enums;

    public class EditWordViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public IList<string> Meanings { get; set; }

        public IList<string> Sentences { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech { get; set; }

        [Required]
        public Array PartOfSpeechPossibleValues => Enum.GetValues(typeof(PartOfSpeech));

        public string Order { get; set; }

        public int CurrentPage { get; set; }
    }
}
