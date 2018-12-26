namespace EnglishDictApp.Web.ViewModels.Word
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Models;

    public class EditWordViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Meaning { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech { get; set; }

        [Required]
        public Array PartOfSpeechPossibleValues => Enum.GetValues(typeof(PartOfSpeech));

        public string Order { get; set; }

        public int CurrentPage { get; set; }
    }
}
