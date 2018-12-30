namespace EnglishDictApp.Data.Models
{
    using System;

    using EnglishDictApp.Data.Common.Models;

    public class Statistic : IAuditInfo, IDeletableEntity
    {
        public int WordId { get; set; }

        public virtual Word Word { get; set; }

        public int ExamId { get; set; }

        public virtual Exam Exam { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public bool IsAnswerRight { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
