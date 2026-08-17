using AutoMapper;
using Monivo.Application.DTOs.Categories;
using Monivo.Application.Features.Categories.Commands.CreateCategory;
using Monivo.Application.Features.Categories.Commands.UpdateCategory;
using Monivo.Application.Features.Categories.Queries.GetAllCategories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, Features.Categories.Queries.GetAllCategories.CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
        }
    }
}
