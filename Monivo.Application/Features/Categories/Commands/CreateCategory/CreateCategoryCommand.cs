using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest
    {
        public string CategoryName { get; set; }
        public int TypeParameterId { get; set; }

        public int UserId { get; set; }
    }
}
