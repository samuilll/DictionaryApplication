namespace EnglishDictApp.Data.Models
{
    using System;

    using EnglishDictApp.Data.Common.Models;

    public class UserWord : IAuditInfo, IDeletableEntity
    {
        public string UserId { get; set; }

        public int WordId { get; set; }

        public ApplicationUser User { get; set; }

        public Word Word { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
