namespace EnglishDictApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EnglishDictApp.Data.Common.Models;

    public class WordSentence : IAuditInfo, IDeletableEntity
    {
        public virtual Word Word { get; set; }

        public int WordId { get; set; }

        public virtual Sentence Sentence { get; set; }

        public int SentenceId { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
