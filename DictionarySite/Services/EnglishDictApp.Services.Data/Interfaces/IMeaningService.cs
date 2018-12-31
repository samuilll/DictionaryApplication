using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDictApp.Services.Data.Interfaces
{
    public interface IMeaningService
    {
        Task CreateMeanings(int wordId, IList<string> meanings);
    }
}
