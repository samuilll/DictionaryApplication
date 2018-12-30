namespace EnglishDictApp.Web.AutoMapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using EnglishDictApp.Data.Models;
    using EnglishDictApp.Web.ViewModels.Exam;
    using EnglishDictApp.Web.ViewModels.Sentence;
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

            this.CreateMap<Sentence, SentenceViewModel>().ReverseMap();

            this.CreateMap<Word, WordInExamViewModel>()
                .ForMember(dest => dest.Sentences, src => src.MapFrom(w => w.WordSentences.Select(ws => ws.Sentence.Content).ToList()))
                .ReverseMap();
            
            this.CreateMap<ExamCreateViewModel, ExamInProgressViewModel>().ReverseMap();

            this.CreateMap<ExamInProgressViewModel, ExamAnswerViewModel>().ReverseMap();

        }

    }
}
