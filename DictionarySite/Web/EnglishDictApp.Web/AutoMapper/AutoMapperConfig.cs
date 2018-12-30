namespace EnglishDictApp.Web.AutoMapper
{
    using System;

    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Web.ViewModels.Exam;
    using EnglishDictApp.Web.ViewModels.Word;
    using global::AutoMapper;

    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            this.CreateMap<Word, WordInListViewModel>().ReverseMap();

            this.CreateMap<Word, EditWordViewModel>().ReverseMap();

            this.CreateMap<Word, CreateWordViewModel>().ReverseMap();

            this.CreateMap<Word, DeleteWordViewModel>().ReverseMap();

            this.CreateMap<Word, WordInExamViewModel>().ReverseMap();

            this.CreateMap<ExamCreateViewModel, ExamInProgressViewModel>().ReverseMap();

            this.CreateMap<ExamInProgressViewModel, ExamAnswerViewModel>().ReverseMap();

        }

    }
}
