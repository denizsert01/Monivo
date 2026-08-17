using Microsoft.EntityFrameworkCore;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;
using Monivo.Persistence.Context;

namespace Monivo.Persistence.Repositories
{
    public class TransactionRepository
        : Repository<Transaction>, ITransactionRepository
    {
        private readonly MonivoDbContext _context;

        public TransactionRepository(MonivoDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetByUserIdAsync(int userId)
        {
            return await _context.Transactions
                .Where(x => x.UserId == userId)
                .Include(x => x.Category)
                 .ThenInclude(x => x.TypeParameter)
                .ToListAsync();
        }

        public async Task<Transaction?> GetByIdAndUserIdAsync(
            int id,
            int userId)
        {
            return await _context.Transactions
                .Include(x => x.Category)
                 .ThenInclude(x => x.TypeParameter)
                .FirstOrDefaultAsync(
                    x => x.Id == id && x.UserId == userId);
        }
    }
}
