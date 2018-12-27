using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Word
{
    public class DeleteWordViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Order { get; set; }

        public int CurrentPage { get; set; }
    }
}
