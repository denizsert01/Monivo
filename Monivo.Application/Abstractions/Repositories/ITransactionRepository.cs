using Monivo.Domain.Entities;

namespace Monivo.Application.Abstractions.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<List<Transaction>> GetByUserIdAsync(int userId);

        Task<Transaction?> GetByIdAndUserIdAsync(int id, int userId);
    }
}
