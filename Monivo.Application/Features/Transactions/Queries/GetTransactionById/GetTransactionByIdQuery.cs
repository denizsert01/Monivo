using MediatR;
using Monivo.Application.DTOs.Transactions;

namespace Monivo.Application.Features.Transactions.Queries.GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<TransactionDto?>
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public GetTransactionByIdQuery(int id, int userId)
        {
            Id = id;
            UserId = userId;
        }
    }
}
