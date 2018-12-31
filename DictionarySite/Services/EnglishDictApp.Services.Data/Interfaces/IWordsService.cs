namespace EnglishDictApp.Services.Data.Interfaces
{
    using System.Linq;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Models;

    public interface IWordsService
    {
        IQueryable<Word> All(string order);

        int GetTotalCount();

        Task<Word> GetByIdAsync(int id);

        Task Update(Word word);

        Task Create(Word word);

        Word GetByTitle(string title);

        Task Delete(Word word);
    }
}
