namespace EnglishDictApp.Web.ViewModels.Exam
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Data.Models.Enums;
    using EnglishDictApp.Web.ViewModels.Word;

    public class ExamInProgressViewModel
    {
        public ExamInProgressViewModel()
        {
            this.Statistics = new List<Statistic>();
        }

        public int UserId { get; set; }

        public Stack<WordInExamViewModel> Words { get; set; }

        [Required]
        [Range(maximum: 11500, minimum: 1)]
        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public double Grade { get; set; }

        public WordInExamViewModel CurrentQuestion { get; set; }

        public string CurrentAnswer { get; set; }

        public bool IsCurrentAnswerRight { get; set; }

        public int CurrentQuestionSequelNumber { get; set; }

        public Difficulty ExamDifficulty { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }
    }
}
