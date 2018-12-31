using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EnglishDictApp.Data.Models;

namespace EnglishDictApp.Services.Data.Interfaces
{
    public interface IMeaningService
    {
        Task CreateMeanings(int wordId, IList<string> meanings);
        Task DeleteMeanings(IEnumerable<Meaning> meanings);
        Task Update(IList<int> enumerable1, IList<string> enumerable2);
    }
}
