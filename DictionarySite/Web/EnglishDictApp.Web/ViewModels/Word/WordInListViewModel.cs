namespace EnglishDictApp.Web.ViewModels.Word
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Models.Enums;

    public class WordInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public IList<string> Meanings { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }

        public string Order { get; set; }

        public int CurrentPage { get; set; }
    }
}
