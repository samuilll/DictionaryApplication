﻿namespace EnglishDictApp.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using EnglishDictApp.Data.Common.Models;

    public class Meaning : BaseDeletableModel<int>
    {
        [Required]
        public int WordId { get; set; }

        public virtual Word Word { get; set; }

        [Required]
        [StringLength(maximumLength: 500, MinimumLength = 1)]
        public string Content { get; set; }
    }
}
