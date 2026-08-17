using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monivo.Application.Abstractions.Services;
using Monivo.Application.Features.Categories.Commands.CreateCategory;
using Monivo.Application.Features.Categories.Commands.DeleteCategory;
using Monivo.Application.Features.Categories.Commands.UpdateCategory;
using Monivo.Application.Features.Categories.Queries.GetAllCategories;
using Monivo.Application.Features.Categories.Queries.GetCategoryById;
using Monivo.Application.Features.Parameters.Queries.GetByType;
using Monivo.Web.ViewModels.Categories;
using System.Security.Claims;

namespace Monivo.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMediator _mediator;

        private int GetCurrentUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(userId!);
        }

        public CategoryController(ICategoryService categoryService, IMediator mediator)
        {
            _categoryService = categoryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();

            var categories = await _mediator.Send(
                new GetAllCategoriesQuery(userId)
            );

            return View(categories);
        }

        public async Task<IActionResult> Create()
        {
            var types = await _mediator.Send(
        new GetParametersByTypeQuery("TransactionType"));

            var model = new CreateCategoryViewModel
            {
                TransactionTypes = types.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ParamValue
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var types = await _mediator.Send(
                    new GetParametersByTypeQuery("TransactionType"));

                model.TransactionTypes = types.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ParamValue
                }).ToList();

                return View(model);
            }

            var command = new CreateCategoryCommand
            {
                CategoryName = model.CategoryName,
                TypeParameterId = model.TypeParameterId,
                UserId = GetCurrentUserId()
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetCurrentUserId();

            var category = await _mediator.Send(new GetCategoryByIdQuery(id, userId));

            if (category == null)
                return NotFound();

            var types = await _mediator.Send(
        new GetParametersByTypeQuery("TransactionType"));

            var model = new EditCategoryViewModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                TypeParameterId = category.TypeParameterId,

                TransactionTypes = types.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ParamValue
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var types = await _mediator.Send(
                    new GetParametersByTypeQuery("TransactionType"));

                model.TransactionTypes = types.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.ParamValue
                }).ToList();

                return View(model);
            }

            var command = new UpdateCategoryCommand
            {
                Id = model.Id,
                CategoryName = model.CategoryName,
                TypeParameterId = model.TypeParameterId,
                UserId = GetCurrentUserId()
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();
            var category = await _mediator.Send(new GetCategoryByIdQuery(id, userId));

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
            command.UserId = GetCurrentUserId();

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    
    }
}
