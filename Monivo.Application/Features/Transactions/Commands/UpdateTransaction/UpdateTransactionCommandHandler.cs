using MediatR;
using Monivo.Application.Abstractions.Repositories;

namespace Monivo.Application.Features.Transactions.Commands.UpdateTransaction
{
    public class UpdateTransactionCommandHandler
       : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICategoryRepository _categoryRepository;

        public UpdateTransactionCommandHandler(
            ITransactionRepository transactionRepository,
            ICategoryRepository categoryRepository)
        {
            _transactionRepository = transactionRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task Handle(
            UpdateTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var transaction =
                await _transactionRepository.GetByIdAndUserIdAsync(
                    request.Id,
                    request.UserId);

            if (transaction == null)
            {
                throw new UnauthorizedAccessException(
                    "You are not authorized to update this transaction.");
            }

            var category =
                await _categoryRepository.GetByIdAndUserIdAsync(
                    request.CategoryId,
                    request.UserId);

            if (category == null)
            {
                throw new UnauthorizedAccessException(
                    "The selected category does not belong to this user.");
            }
            transaction.CategoryId = request.CategoryId;
            transaction.Amount = request.Amount;
            transaction.TransactionDate = request.TransactionDate;
            transaction.Description = request.Description;

            _transactionRepository.Update(transaction);

            await _transactionRepository.SaveChangesAsync();
        }
    }

    }
