namespace EnglishDictApp.Web.Controllers
{
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Web.ViewModels;
    using EnglishDictApp.Web.ViewModels.Word;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;

    public class WordsController : BaseController
    {
        private const int WordsPerPage = 10;

        private IWordsService wordsService;
        private IMapper mapper;

        public WordsController(IWordsService wordsService, IMapper mapper)
        {
            this.wordsService = wordsService;
            this.mapper = mapper;
        }

        public IActionResult AllWords(int currentPage=1)
        {
            AllWordsViewModel model = new AllWordsViewModel()
            {
                Words = this.wordsService.All()
                .Skip((currentPage - 1) * WordsPerPage)
                .Take(WordsPerPage)
                .ProjectTo<WordInListViewModel>(this.mapper.ConfigurationProvider)
                .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = WordsPerPage,
                    TotalItems = this.wordsService.All().Count(),
                },
            };

            return this.View("AllWords", model);
        }
    }
}
