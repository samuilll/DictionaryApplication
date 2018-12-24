using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.ViewModels.Word
{
    public class AllWordsViewModel
    {
        public ICollection<WordInListViewModel> Words { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
