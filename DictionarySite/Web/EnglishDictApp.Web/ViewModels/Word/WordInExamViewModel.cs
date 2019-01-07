namespace EnglishDictApp.Web.ViewModels.Word
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Models.Enums;

    public class WordInExamViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Required]
        public IList<string> Meanings { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }

        public IList<string> Sentences { get; set; }
    }
}
