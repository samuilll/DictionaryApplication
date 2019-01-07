namespace EnglishDictApp.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Web.Helpers;
    using EnglishDictApp.Web.ViewModels.Exam;
    using EnglishDictApp.Web.ViewModels.Word;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ExamController : BaseController
    {
        private IMapper mapper;
        private IExamService examService;
        private IWordsService wordService;
        private IDeletableEntityRepository<Word> words;
        private UserManager<ApplicationUser> userManager;

        public ExamController(IMapper mapper, IExamService examService, IWordsService wordService, IDeletableEntityRepository<Word> words, UserManager<ApplicationUser> userManager)
        {
            this.mapper = mapper;
            this.examService = examService;
            this.wordService = wordService;
            this.words = words;
            this.userManager = userManager;
        }

        public IActionResult Create()
        {

            ExamCreateViewModel model = new ExamCreateViewModel();

            model.TotalWordsCount = this.wordService.GetTotalCount();
            model.UserId = this.userManager.GetUserId(this.HttpContext.User);
            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ExamCreateViewModel model)
        {
            if (!this.ModelState.IsValid || !model.IsValidExam)
            {
                return this.View("Error");
            }

            ExamInProgressViewModel examInProgress = this.mapper.Map<ExamInProgressViewModel>(model);

            IQueryable<Word> words = this.examService.GetNeededWords(
               model.Order.ToString(),
               model.FromWord,
               model.ToWord,
               model.NumberOfQuestions);

            examInProgress.Words = new Stack<WordInExamViewModel>();

            this.CustomProjectTo(examInProgress, words);

            this.HttpContext.Session.SetObject("exam", examInProgress);

            return this.RedirectToAction("AskQuestion");
        }

        [HttpGet]
        public IActionResult AskQuestion(bool isRightAnswer = false)
        {
            ExamInProgressViewModel currentExam = this.HttpContext.Session.GetObject<ExamInProgressViewModel>("exam");

            if (currentExam.Words.Count == 0)
            {
                ExamResultViewModel resultModel = this.mapper.Map<ExamResultViewModel>(currentExam);
                return this.RedirectToAction("Result", resultModel);
            }

            if (isRightAnswer)
            {
                currentExam.RightAnswers += 1;
            }

            currentExam.CurrentQuestion = currentExam.Words.Pop();

            currentExam.CurrentQuestionSequelNumber += 1;

            ExamAnswerViewModel model = this.mapper.Map<ExamAnswerViewModel>(currentExam);


            this.HttpContext.Session.SetObject("exam", currentExam);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult AnswerToAnswer(ExamAnswerViewModel model)
        {
            return this.View(model);
        }

        public async Task<IActionResult> Result(ExamResultViewModel model)
        {
            Exam exam = this.mapper.Map<Exam>(model);
            await this.examService.Add(exam);
            return this.View(model);
        }

        private void CustomProjectTo(ExamInProgressViewModel examInProgress, IQueryable<Word> words)
        {
            foreach (var word in words)
            {
                examInProgress.Words.Push(this.mapper.Map<WordInExamViewModel>(word));
            }
        }
    }
}
