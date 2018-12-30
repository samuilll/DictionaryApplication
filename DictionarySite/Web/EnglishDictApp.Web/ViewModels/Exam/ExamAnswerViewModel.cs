using EnglishDictApp.Web.ViewModels.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Exam
{
    public class ExamAnswerViewModel
    {
        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public WordInExamViewModel CurrentQuestion { get; set; }

        [Required]
        [DisplayName("Answer")]
        public string CurrentAnswer { get; set; }

        public bool IsCurrentAnswerRight => this.CurrentAnswer != null ?
            this.CurrentAnswer.Trim() == this.CurrentQuestion.Title
            : false;

        public int CurrentQuestionSequelNumber { get; set; }
    }
}
