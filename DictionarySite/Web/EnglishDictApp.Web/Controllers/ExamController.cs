namespace EnglishDictApp.Web.Controllers
{
    using EnglishDictApp.Data;
    using EnglishDictApp.Data.Common.Repositories;
    using EnglishDictApp.Data.Models;
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
    using System.Linq;

    public class ExamController : BaseController
    {
        private IMapper mapper;
        private IExamService examService;
        private IWordsService wordService;
        private IDeletableEntityRepository<Word> words;

        public ExamController(IMapper mapper, IExamService examService, IWordsService wordService, IDeletableEntityRepository<Word> words)
        {
            this.mapper = mapper;
            this.examService = examService;
            this.wordService = wordService;
            this.words = words;
        }

        public IActionResult Create()
        {
            // Tests
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

        private void CustomProjectTo(ExamInProgressViewModel examInProgress, IQueryable<Word> words)
        {
            foreach (var word in words)
            {
                examInProgress.Words.Push(this.mapper.Map<WordInExamViewModel>(word));
            }
        }
    }
}
