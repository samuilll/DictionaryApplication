using AutoMapper;
using EnglishDictApp.Data.Models;
using EnglishDictApp.Web.ViewModels.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnglishDictApp.Web.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Word, WordInListViewModel>();
        }

    }
}
