namespace EnglishDictApp.Web.ViewModels.Exam
{
    using System;
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

        public string UserId { get; set; }

        public Stack<WordInExamViewModel> Words { get; set; }

        [Required]
        [Range(maximum: 11500, minimum: 1)]
        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public double Grade
        {
            get
            {
                int divider = this.CurrentQuestionSequelNumber != 0 ? this.CurrentQuestionSequelNumber : 1;

                double percent = ((double)this.RightAnswers / divider) * 100;

                return (percent * 0.04) + 2;
            }
        }


        public WordInExamViewModel CurrentQuestion { get; set; }

        public string CurrentAnswer { get; set; }

        public bool IsCurrentAnswerRight { get; set; }

        public int CurrentQuestionSequelNumber { get; set; }

        public Difficulty ExamDifficulty { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }
    }
}
