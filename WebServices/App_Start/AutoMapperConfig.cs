using AutoMapper;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServices.Models.OutputModels.Categories;

namespace WebServices.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryOutputModel>()
                .ForMember(x => x.ProductsCounter, d => d.MapFrom(s => s.Products.Count));
        }
    }
}