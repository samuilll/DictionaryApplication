namespace EnglishDictApp.Web.AutoMapper
{
    using System;

    using EnglishDictApp.Data.Models;
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

        }

    }
}
