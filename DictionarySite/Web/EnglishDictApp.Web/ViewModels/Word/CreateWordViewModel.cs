using EnglishDictApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Word
{
    public class CreateWordViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Meaning { get; set; }

        [Required]
        public PartOfSpeech PartOfSpeech { get; set; }

        public Array PartOfSpeechPossibleValues => Enum.GetValues(typeof(PartOfSpeech));
    }
}
