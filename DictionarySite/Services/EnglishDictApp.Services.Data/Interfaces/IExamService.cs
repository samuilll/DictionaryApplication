namespace EnglishDictApp.Services.Data.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;
    using EnglishDictApp.Data.Models;

    public interface IExamService
    {
        IQueryable<Word> GetNeededWords(string order, int fromWord, int toWord, int numberOfQuestions);

        Task Add(Exam exam);
    }
}
