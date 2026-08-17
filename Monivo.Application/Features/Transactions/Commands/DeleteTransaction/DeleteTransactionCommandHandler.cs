using MediatR;
using Monivo.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Application.Features.Transactions.Commands.DeleteTransaction
{
    public class DeleteTransactionCommandHandler
        : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(
            ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task Handle(
            DeleteTransactionCommand request,
            CancellationToken cancellationToken)
        {
            var transaction =
                await _transactionRepository.GetByIdAndUserIdAsync(
                    request.Id,
                    request.UserId);

            if (transaction == null)
            {
                throw new UnauthorizedAccessException(
                    "You are not authorized to delete this transaction.");
            }

            _transactionRepository.Delete(transaction);

            await _transactionRepository.SaveChangesAsync();
        }
    }
    }
