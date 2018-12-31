namespace EnglishDictApp.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Data.Interfaces;

    public class SentenceService : ISentenceService
    {
        private IDeletableEntityRepository<Sentence> sentences;
        private IDeletableEntityRepository<WordSentence> wordsSentences;

        public SentenceService(IDeletableEntityRepository<Sentence> sentences, IDeletableEntityRepository<WordSentence> wordsSentences)
        {
            this.sentences = sentences;
            this.wordsSentences = wordsSentences;
        }

        public async Task CreateSentences(int wordId, IList<string> sentences)
        {
            foreach (string sentenceContent in sentences)
            {
                Sentence sentence = new Sentence()
                {
                    Content = sentenceContent,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };

                WordSentence wordSentence = new WordSentence()
                {
                    WordId = wordId,
                    Sentence = sentence,
                    CreatedOn = DateTime.Now,
                    IsDeleted = false,
                };

                await this.wordsSentences.Add(wordSentence);
            }
        }

        public async Task DeleteSentences(IEnumerable<WordSentence> sentences)
        {
            foreach (WordSentence wordSentence in sentences)
            {
                this.wordsSentences.Delete(wordSentence);

                await this.wordsSentences.Update(wordSentence);
            }
        }

        public async Task Update(IList<int> sentenceIds, IList<string> sentenceContents)
        {
            for (int i = 0; i < sentenceIds.Count(); i++)
            {
                Sentence sentence = await this.sentences.GetByIdAsync(sentenceIds[i]);

                sentence.Content = sentenceContents[i];

                await this.sentences.Update(sentence);
            }
        }
    }
}
