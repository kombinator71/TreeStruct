using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeStruct.Models;
using TreeStruct.ViewModels;

namespace TreeStruct.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TreeViewModel, Category>();
            CreateMap<Category, TreeViewModel>();
        }
    }
}
