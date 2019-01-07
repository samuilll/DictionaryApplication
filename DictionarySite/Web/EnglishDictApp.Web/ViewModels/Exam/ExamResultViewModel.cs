using EnglishDictApp.Data.Models;
using EnglishDictApp.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Exam
{
    public class ExamResultViewModel
    {
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public double Grade { get; set; }

        public Difficulty ExamDifficulty { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }
    }
}
