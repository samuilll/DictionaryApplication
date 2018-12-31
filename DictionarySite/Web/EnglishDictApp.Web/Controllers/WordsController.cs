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
        private IMeaningService meaningService;
        private ISentenceService sentenceService;

        private IMapper mapper;

        public WordsController(IWordsService wordsService, IMeaningService meaningService, ISentenceService sentenceService, IMapper mapper)
        {
            this.wordsService = wordsService;
            this.meaningService = meaningService;
            this.sentenceService = sentenceService;
            this.mapper = mapper;
        }

        public IActionResult AllWords(int currentPage = 1, string order = "title")
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
            

            await Task.Run(() => this.wordsService.Update(word));

            this.TempData["SuccessfullEdit"] = $"{word.Title} {word.PartOfSpeech.ToString()}";

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

            await this.wordsService.Create(word);

            int wordId = this.wordsService.GetByTitle(model.Title).Id;

            await this.meaningService.CreateMeanings(wordId, model.Meanings);
            await this.sentenceService.CreateSentences(word.Id, model.Sentences);

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
