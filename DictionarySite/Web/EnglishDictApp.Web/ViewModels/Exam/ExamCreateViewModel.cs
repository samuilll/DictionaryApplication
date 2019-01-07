namespace EnglishDictApp.Web.ViewModels.Exam
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Models.Enums;

    public class ExamCreateViewModel
    {
        public string UserId { get; set; }

        [Required]
        [DisplayName("Questions' number")]
        [DefaultValue(1)]
        public int NumberOfQuestions { get; set; }

        [Required]
        [DisplayName("From word")]
        [DefaultValue(1)]
        public int FromWord { get; set; }

        [Required]
        [DisplayName("To word")]
        [DefaultValue(1)]
        public int ToWord { get; set; }

        public bool IsValidExam => (this.ToWord - this.FromWord) >= this.NumberOfQuestions-1;

        public int TotalWordsCount { get; set; }

        [Required]
        [DisplayName("Difficulty level")]
        public Difficulty ExamDifficulty { get; set; }

        [Required]
        [DisplayName("Order by")]
        public Order Order { get; set; }

        public Array PossibleDiffucultyLevels => Enum.GetValues(typeof(Difficulty));

        public Array PossibleOrderChoices => Enum.GetValues(typeof(Order));
    }
}
