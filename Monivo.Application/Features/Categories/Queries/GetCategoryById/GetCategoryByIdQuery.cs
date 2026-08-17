using MediatR;
using Monivo.Application.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public GetCategoryByIdQuery(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
