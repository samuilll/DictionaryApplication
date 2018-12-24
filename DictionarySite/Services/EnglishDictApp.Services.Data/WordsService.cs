namespace EnglishDictApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Data.Interfaces;

    public class WordsService : IWordsService
    {
        private IRepository<Word> words;

        public WordsService(IRepository<Word> words)
        {
            this.words = words;
        }

        public IQueryable<Word> All()
        {
            return this.words.All();
        }
    }
}
