using EnglishDictApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Word
{
    public class WordInExamViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Meaning { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }
    }
}
