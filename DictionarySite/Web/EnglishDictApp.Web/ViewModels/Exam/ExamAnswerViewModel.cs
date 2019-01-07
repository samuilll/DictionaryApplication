namespace EnglishDictApp.Web.ViewModels.Exam
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Web.ViewModels.Word;

    public class ExamAnswerViewModel
    {
        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public WordInExamViewModel CurrentQuestion { get; set; }

        public double Grade
        {
            get
            {
                int divider = this.CurrentQuestionSequelNumber != 0 ? this.CurrentQuestionSequelNumber : 1;

                double percent = ((double)this.RightAnswers / divider) * 100;

                return (percent * 0.04) + 2;
            }
        }

        [Required]
        [DisplayName("Answer")]
        public string CurrentAnswer { get; set; }

        public bool IsCurrentAnswerRight => this.CurrentAnswer != null ?
            this.CurrentAnswer.Trim() == this.CurrentQuestion.Title
            : false;

        public int CurrentQuestionSequelNumber { get; set; }
    }
}
