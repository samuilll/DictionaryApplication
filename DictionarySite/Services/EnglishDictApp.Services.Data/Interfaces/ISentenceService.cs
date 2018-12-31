using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDictApp.Services.Data.Interfaces
{
    public interface ISentenceService
    {
        Task CreateSentences(int wordId, IList<string> sentences);
    }
}
