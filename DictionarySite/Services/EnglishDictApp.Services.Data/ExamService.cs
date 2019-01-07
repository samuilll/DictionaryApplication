namespace EnglishDictApp.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Data.Models.Enums;
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Services.LINQHelpers;

    public class ExamService : IExamService
    {
        private IWordsService wordService;
        private IDeletableEntityRepository<Exam> exams;

        public ExamService(IWordsService wordService, IDeletableEntityRepository<Exam> exams)
        {
            this.wordService = wordService;
            this.exams = exams;
        }

        public async Task Add(Exam exam)
        {
            await this.exams.Add(exam);
        }

        public IQueryable<Word> GetNeededWords(string order, int fromWord, int toWord, int numberOfQuestions)
        {
            var wordsRange = toWord - fromWord + 1;

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
