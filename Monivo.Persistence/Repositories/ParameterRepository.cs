using Microsoft.EntityFrameworkCore;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;
using Monivo.Persistence.Context;

namespace Monivo.Persistence.Repositories
{
    public class ParameterRepository : Repository<Parameter>, IParameterRepository
    {
        private readonly MonivoDbContext _context;

        public ParameterRepository(MonivoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Parameter>> GetByTypeAsync(string paramType)
        {
            return await _context.Parameters
                .Where(x => x.ParamType == paramType && x.IsActive)
                .ToListAsync();
        }
    }
}
