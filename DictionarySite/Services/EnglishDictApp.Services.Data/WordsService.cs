namespace EnglishDictApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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

        public IQueryable<Word> All(string order)
        {
            switch (order.ToLower())
            {
                case "createdon":
                    {
                        return this.words.All();
                    }

                case "createdondescending":
                    {
                        return this.words.All().OrderByDescending(m => m.Id);
                    }

                case "title":
                    {
                        return this.words.All().OrderBy(m => m.Title);
                    }

                case "titledescending":
                    {
                        return this.words.All().OrderByDescending(m => m.Title);
                    }

                case "partofspeech":
                    {
                        return this.words.All().OrderBy(m => m.PartOfSpeech);
                    }

                case "partofspeechdescending":
                    {
                        return this.words.All().OrderByDescending(m => m.PartOfSpeech);
                    }

                default:
                    return this.words.All();
            }
        }

        public async Task<Word> GetByIdAsync(int id)
        {
            var word = await this.words.GetByIdAsync(id);

            return word;
        }

        public int GetTotalCount()
        {
            return this.words.All().Count();
        }

        public void UpdateWord(Word word)
        {
             this.words.Update(word);
        }
    }
}
