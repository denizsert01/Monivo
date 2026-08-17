using AutoMapper;
using Monivo.Application.DTOs.Categories;
using Monivo.Application.DTOs.Transactions;
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
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand, Category>().ReverseMap();
            CreateMap<Transaction, TransactionDto>()
    .ForMember(
        dest => dest.CategoryName,
        opt => opt.MapFrom(src => src.Category.CategoryName));

            CreateMap<Transaction, TransactionDto>()
    .ForMember(
        dest => dest.CategoryName,
        opt => opt.MapFrom(src => src.Category.CategoryName))
    .ForMember(
        dest => dest.TransactionType,
        opt => opt.MapFrom(src => src.Category.TypeParameter.ParamValue));


        }
    }
}
