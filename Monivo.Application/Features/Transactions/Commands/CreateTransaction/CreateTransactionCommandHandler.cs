using MediatR;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Transactions.Commands.CreateTransaction
{
    public class CreateTransactionCommandHandler
       : IRequestHandler<CreateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateTransactionCommandHandler(
            ITransactionRepository transactionRepository,
            ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(
            CreateTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var category = await _categoryRepository
                .GetByIdAndUserIdAsync(request.CategoryId, request.UserId);
            if (category == null)
            {
                throw new UnauthorizedAccessException(
                    "The selected category does not belong to this user.");
            }

            var transaction = new Transaction
            {
                UserId = request.UserId,
                CategoryId = request.CategoryId,
                Amount = request.Amount,
                TransactionDate = request.TransactionDate,
                Description = request.Description
            };

            await _transactionRepository.AddAsync(transaction);
            await _transactionRepository.SaveChangesAsync();
        }
    }
}
