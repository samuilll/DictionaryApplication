namespace EnglishDictApp.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EnglishDictApp.Data.Common.Models;
    using EnglishDictApp.Data.Models.Enums;

    public class Exam : BaseDeletableModel<int>
    {
        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        [Range(maximum: 11500, minimum: 1)]
        public int NumberOfQuestions { get; set; }

        public int RightAnswers { get; set; }

        public double Grade { get; set; }

        public Difficulty ExamDifficulty { get; set; }

        public virtual IEnumerable<Statistic> Statistics { get; set; }
   }
}
