using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Monivo.Application.Features.Categories.Queries.GetAllCategories;
using Monivo.Application.Features.Transactions.Commands.CreateTransaction;
using Monivo.Application.Features.Transactions.Commands.DeleteTransaction;
using Monivo.Application.Features.Transactions.Commands.UpdateTransaction;
using Monivo.Application.Features.Transactions.Queries.GetAllTransactions;
using Monivo.Application.Features.Transactions.Queries.GetTransactionById;
using Monivo.Web.ViewModels.Transactions;
using System.Security.Claims;

namespace Monivo.Web.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        private int GetCurrentUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return int.Parse(userId!);
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();

            var transactions = await _mediator.Send(
                new GetAllTransactionsQuery(userId));

            return View(transactions);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = GetCurrentUserId();

            var categories = await _mediator.Send(
                new GetAllCategoriesQuery(userId));

            var model = new CreateTransactionViewModel
            {
                Categories = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = GetCurrentUserId();

                var categories = await _mediator.Send(
                    new GetAllCategoriesQuery(userId));

                model.Categories = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToList();

                return View(model);
            }

            var command = new CreateTransactionCommand
            {
                UserId = GetCurrentUserId(),
                CategoryId = model.CategoryId,
                Amount = model.Amount,
                TransactionDate = model.TransactionDate,
                Description = model.Description
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = GetCurrentUserId();

            var transaction = await _mediator.Send(
                new GetTransactionByIdQuery(id, userId));

            if (transaction == null)
                return NotFound();

            var categories = await _mediator.Send(
                new GetAllCategoriesQuery(userId));

            var model = new EditTransactionViewModel
            {
                Id = transaction.Id,
                CategoryId = transaction.CategoryId,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate,
                Description = transaction.Description,

                Categories = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToList()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditTransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = GetCurrentUserId();

                var categories = await _mediator.Send(
                    new GetAllCategoriesQuery(userId));

                model.Categories = categories.Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.CategoryName
                }).ToList();

                return View(model);
            }

            var command = new UpdateTransactionCommand
            {
                Id = model.Id,
                UserId = GetCurrentUserId(),
                CategoryId = model.CategoryId,
                Amount = model.Amount,
                TransactionDate = model.TransactionDate,
                Description = model.Description
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetCurrentUserId();

            var transaction = await _mediator.Send(
                new GetTransactionByIdQuery(id, userId));

            if (transaction == null)
                return NotFound();

            var model = new DeleteTransactionViewModel
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                TransactionDate = transaction.TransactionDate,
                Description = transaction.Description,
                CategoryName = transaction.CategoryName
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTransactionViewModel model)
        {
            var command = new DeleteTransactionCommand
            {
                Id = model.Id,
                UserId = GetCurrentUserId()
            };

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }
    }
}
