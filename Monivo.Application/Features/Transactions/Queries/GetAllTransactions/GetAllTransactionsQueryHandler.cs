using AutoMapper;
using MediatR;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Application.DTOs.Transactions;

namespace Monivo.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQueryHandler
        : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public GetAllTransactionsQueryHandler(
            ITransactionRepository transactionRepository,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _mapper = mapper;
        }

        public async Task<List<TransactionDto>> Handle(
            GetAllTransactionsQuery request,
            CancellationToken cancellationToken)
        {
            var transactions =
                await _transactionRepository.GetByUserIdAsync(request.UserId);

            return _mapper.Map<List<TransactionDto>>(transactions);
        }
    }
}
