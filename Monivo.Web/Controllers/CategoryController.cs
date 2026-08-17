using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monivo.Application.Abstractions.Services;
using Monivo.Application.Features.Categories.Commands.CreateCategory;
using Monivo.Application.Features.Categories.Commands.DeleteCategory;
using Monivo.Application.Features.Categories.Commands.UpdateCategory;
using Monivo.Application.Features.Categories.Queries.GetAllCategories;
using Monivo.Application.Features.Categories.Queries.GetCategoryById;

namespace Monivo.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMediator _mediator;

        public CategoryController(ICategoryService categoryService, IMediator mediator)
        {
            _categoryService = categoryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _mediator.Send(new GetAllCategoriesQuery());
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (category == null)
                return NotFound();

            var command = new UpdateCategoryCommand
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _mediator.Send(new GetCategoryByIdQuery(id));

            if (category == null)
                return NotFound();

            var command = new DeleteCategoryCommand
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            };

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    
    }
}
