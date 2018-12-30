namespace EnglishDictApp.Web.Controllers
{
    using EnglishDictApp.Services.Data.Interfaces;
    using EnglishDictApp.Web.Helpers;
    using EnglishDictApp.Web.ViewModels.Exam;
    using EnglishDictApp.Web.ViewModels.Word;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class ExamController : BaseController
    {
        private IMapper mapper;
        private IExamService examService;
        private IWordsService wordService;

        public ExamController(IMapper mapper, IExamService examService, IWordsService wordService)
        {
            this.mapper = mapper;
            this.examService = examService;
            this.wordService = wordService;
        }

        public IActionResult Create()
        {
            ExamCreateViewModel model = new ExamCreateViewModel();

            model.TotalWordsCount = this.wordService.GetTotalCount();

            return this.View(model);
        }

        [HttpPost]
        public IActionResult Create(ExamCreateViewModel model)
        {
            if (!this.ModelState.IsValid || !model.IsValidExam)
            {
                return this.RedirectToAction("Error");
            }

            ExamInProgressViewModel examInProgress = this.mapper.Map<ExamInProgressViewModel>(model);

            examInProgress.Words = new Stack<WordInExamViewModel>
                (this.examService.GetNeededWords(
                model.Order.ToString(),
                model.FromWord,
                model.ToWord,
                model.NumberOfQuestions)
                .ProjectTo<WordInExamViewModel>(this.mapper.ConfigurationProvider));

            this.HttpContext.Session.SetObject("exam", examInProgress);

            return this.RedirectToAction("AskQuestion");
        }

        [HttpGet]
        public IActionResult AskQuestion(bool isRightAnswer = false)
        {
            var currentExam = this.HttpContext.Session.GetObject<ExamInProgressViewModel>("exam");

            if (isRightAnswer)
            {
                currentExam.RightAnswers += 1;
            }

            currentExam.CurrentQuestion = currentExam.Words.Pop();

            currentExam.CurrentQuestionSequelNumber += 1;

            var model = this.mapper.Map<ExamAnswerViewModel>(currentExam);

            this.HttpContext.Session.SetObject("exam", currentExam);

            return this.View(model);
        }

        [HttpPost]
        public IActionResult AnswerToAnswer(ExamAnswerViewModel model)
        {
            return this.View(model);
        }
    }
}
