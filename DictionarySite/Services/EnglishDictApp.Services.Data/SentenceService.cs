namespace EnglishDictApp.Services.Data
{
    using System;
    using System.Collections.Generic;
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
    }
}
