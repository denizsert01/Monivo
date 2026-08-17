using MediatR;
using Monivo.Application.DTOs.Transactions;

namespace Monivo.Application.Features.Transactions.Queries.GetAllTransactions
{
    public class GetAllTransactionsQuery
        : IRequest<List<TransactionDto>>
    {
        public int UserId { get; set; }

        public GetAllTransactionsQuery(int userId)
        {
            UserId = userId;
        }
    }
}
