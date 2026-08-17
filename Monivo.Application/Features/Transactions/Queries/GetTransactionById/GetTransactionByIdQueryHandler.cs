using AutoMapper;
using MediatR;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Application.DTOs.Transactions;

namespace Monivo.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQueryHandler
        : IRequestHandler<GetTransactionByIdQuery, TransactionDto?>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetTransactionByIdQueryHandler(
            ITransactionRepository transactionRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<TransactionDto?> Handle(
            GetTransactionByIdQuery request,
            CancellationToken cancellationToken)
        {
            var transaction =
                await _transactionRepository.GetByIdAndUserIdAsync(
                    request.Id,
                    request.UserId);

            if (transaction == null)
                return null;

            return _mapper.Map<TransactionDto>(transaction);
        }
    }
}
