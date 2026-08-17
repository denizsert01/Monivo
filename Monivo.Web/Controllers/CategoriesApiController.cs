using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monivo.Application.Features.Categories.Commands.CreateCategory;

namespace Monivo.Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesApiController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok("Category created successfully.");
        }
    }
}
