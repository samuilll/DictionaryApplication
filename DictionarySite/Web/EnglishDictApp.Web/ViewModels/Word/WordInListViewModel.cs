namespace EnglishDictApp.Web.ViewModels.Word
{
    using EnglishDictApp.Data.Models.Enums;

    public class WordInListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Meaning { get; set; }

        public PartOfSpeech PartOfSpeech { get; set; }

        public string Order { get; set; }

        public int CurrentPage { get; set; }
    }
}
