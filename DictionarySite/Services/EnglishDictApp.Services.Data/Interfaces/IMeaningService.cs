﻿namespace EnglishDictApp.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Models;

    public interface IMeaningService
    {
        Task CreateMeanings(int wordId, IList<string> meanings);

        Task DeleteMeanings(IEnumerable<Meaning> meanings);

        Task Update(IList<int> enumerable1, IList<string> enumerable2);
    }
}
