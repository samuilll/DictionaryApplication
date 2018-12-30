using System.Collections.Generic;
using System.Linq;
using EnglishDictApp.Data.Models;

namespace EnglishDictApp.Services.Data.Interfaces
{
    public interface IExamService
    {
        IQueryable<Word> GetNeededWords(string order, int fromWord, int toWord, int numberOfQuestions);
    }
}
