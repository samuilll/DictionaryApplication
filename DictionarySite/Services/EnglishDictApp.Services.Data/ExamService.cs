namespace EnglishDictApp.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Data.Models.Enums;
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Services.LINQHelpers;

    public class ExamService : IExamService
    {
        private IWordsService wordService;

        public ExamService(IWordsService wordService)
        {
            this.wordService = wordService;
        }

        public IQueryable<Word> GetNeededWords(string order, int fromWord, int toWord, int numberOfQuestions)
        {
            var wordsRange = toWord - fromWord;

            IQueryable<Word> orderedWords = this.wordService
                .All(order)
                .Skip(fromWord - 1)
                .Take(wordsRange);

            if (order == Order.Random.ToString())
            {
                orderedWords = orderedWords.Randomize();
            }

            orderedWords = orderedWords.Take(numberOfQuestions);

            return orderedWords;
        }
    }
}
