using MediatR;
using Monivo.Application.DTOs.Categories;

namespace Monivo.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryDto>>
    {
        public int UserId { get; set; }

        public GetAllCategoriesQuery(int userId)
        {
            UserId = userId;
        }
    }
}
