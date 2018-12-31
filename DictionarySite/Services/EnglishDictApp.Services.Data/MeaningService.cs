namespace EnglishDictApp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Data.Interfaces;

    public class MeaningService : IMeaningService
    {
        private IDeletableEntityRepository<Meaning> meanings;

        public MeaningService(IDeletableEntityRepository<Meaning> meanings)
        {
            this.meanings = meanings;
        }

        public async Task CreateMeanings(int wordId, IList<string> meanings)
        {
            foreach (string meaningContent in meanings)
            {
                Meaning meaning = new Meaning()
                {
                    WordId = wordId,
                    Content = meaningContent,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };

                await this.meanings.Add(meaning);
            }
        }

        public async Task DeleteMeanings(IEnumerable<Meaning> meanings)
        {
            foreach (Meaning meaning in meanings)
            {
                this.meanings.Delete(meaning);

                await this.meanings.Update(meaning);
            }
        }

        public async Task Update(IList<int> meaningIds, IList<string> meaningContents)
        {
            for (int i = 0; i < meaningIds.Count(); i++)
            {
                Meaning meaning = await this.meanings.GetByIdAsync(meaningIds[i]);

                meaning.Content = meaningContents[i];

                await this.meanings.Update(meaning);
            }
        }
    }
}
