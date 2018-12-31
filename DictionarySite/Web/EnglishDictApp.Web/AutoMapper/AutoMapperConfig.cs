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
            this.CreateMap<Word, WordInListViewModel>()
                .ForMember(dest => dest.Meanings, src => src.MapFrom(w => w.Meanings.Select(m => m.Content).ToList()))
                .ReverseMap();

            this.CreateMap<Word, EditWordViewModel>()
                .ForMember(dest => dest.Meanings, src => src.MapFrom(w => w.Meanings.Select(m => m.Content).ToList()))
                .ForMember(dest => dest.Sentences, src => src.MapFrom(w => w.WordSentences.Select(ws => ws.Sentence.Content).ToList()))
                .ReverseMap();

            this.CreateMap<CreateWordViewModel, Word>()
                .ForMember(dest => dest.Meanings, src => src.Ignore())
                .ReverseMap();

            this.CreateMap<Word, DeleteWordViewModel>().ReverseMap();

            this.CreateMap<Sentence, SentenceViewModel>().ReverseMap();

            this.CreateMap<Word, WordInExamViewModel>()
                .ForMember(dest => dest.Sentences, src => src.MapFrom(w => w.WordSentences.Select(ws => ws.Sentence.Content).ToList()))
                .ForMember(dest => dest.Meanings, src => src.MapFrom(w => w.Meanings.Select(m => m.Content).ToList()))
                .ReverseMap();

            this.CreateMap<ExamCreateViewModel, ExamInProgressViewModel>().ReverseMap();

            this.CreateMap<ExamInProgressViewModel, ExamAnswerViewModel>().ReverseMap();

        }

    }
}
