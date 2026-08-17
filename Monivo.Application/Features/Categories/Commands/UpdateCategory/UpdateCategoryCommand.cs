using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int UserId { get; set; }
        public int TypeParameterId { get; set; }
    }
}
