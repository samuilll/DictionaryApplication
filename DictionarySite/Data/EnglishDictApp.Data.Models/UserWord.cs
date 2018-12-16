using EnglishDictApp.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnglishDictApp.Data.Models
{
    public class UserWord:IAuditInfo,IDeletableEntity
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
