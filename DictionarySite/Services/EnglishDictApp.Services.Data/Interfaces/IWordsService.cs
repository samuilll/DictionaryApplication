using EnglishDictApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnglishDictApp.Services.Data.Interfaces
{
    public interface IWordsService
    {
        IQueryable<Word> All();
    }
}
