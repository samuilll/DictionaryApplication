namespace EnglishDictApp.Web.Controllers
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Web.ViewModels;
    using EnglishDictApp.Web.ViewModels.Word;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Mvc;

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

        public IActionResult AllWords(int currentPage = 1, string order = "createdOn")
        {
            AllWordsViewModel model = new AllWordsViewModel()
            {
                Words = this.wordsService.All(order)
                .Skip((currentPage - 1) * WordsPerPage)
                .Take(WordsPerPage)
                .ProjectTo<WordInListViewModel>(this.mapper.ConfigurationProvider)
                .ToList(),

                PagingInfo = new PagingInfo
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = WordsPerPage,
                    TotalItems = this.wordsService.GetTotalCount(),
                },
                Order = order,
            };

            return this.View("AllWords", model);
        }

        public async Task<IActionResult> Edit(int id, string order = "createdOn", int currentPage = 1)
        {
            Word word = await this.wordsService.GetByIdAsync(id);

            EditWordViewModel model = this.mapper.Map<EditWordViewModel>(word);

            model.Order = order;
            model.CurrentPage = currentPage;

           // Task.WaitAll();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditWordViewModel model)
        {
            Word word = await this.wordsService.GetByIdAsync(model.Id);

            word.Title = model.Title;
            word.PartOfSpeech = model.PartOfSpeech;
            word.Meaning = model.Meaning;

            await Task.Run(() => this.wordsService.Update(word));

            this.TempData["SuccessfullEdit"] = $"{word.Title} {word.PartOfSpeech.ToString()} {word.Meaning}";

            Task.WaitAll();

            return this.RedirectToAction("AllWords", new { order = model.Order, currentPage = model.CurrentPage });
        }

        public ActionResult Create()
        {
            CreateWordViewModel model = new CreateWordViewModel();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWordViewModel model)
        {
            Word word = this.mapper.Map<Word>(model);

            await this.wordsService.Add(word);

            this.TempData["SuccessfullCreate"] = $"You have successfully created the word \"{word.Title}\"";

            return this.RedirectToAction("AllWords");
        }

        public async Task<ActionResult> Delete(int id, string ensure = null, string order = "createdOn", int currentPage = 1)
        {

           Word word = await this.wordsService.GetByIdAsync(id);
           DeleteWordViewModel model = this.mapper.Map<DeleteWordViewModel>(word);
           model.Order = order;
           model.CurrentPage = currentPage;

           if (ensure == null)
            {
                 return this.View(model);
            }

           await this.wordsService.Delete(word);

           this.TempData["SuccessfullDelete"] = $"You have successfully deleted the word \"{word.Title}\"";

           return this.RedirectToAction("AllWords", new { order = model.Order, currentPage = model.CurrentPage });
        }
    }
}
