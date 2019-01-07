namespace EnglishDictApp.Services.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Models;

    public interface ISentenceService
    {
        Task CreateSentences(int wordId, IList<string> sentences);

        Task DeleteSentences(IEnumerable<WordSentence> sentences);

        Task Update(IList<int> enumerable1, IList<string> enumerable2);
    }
}
