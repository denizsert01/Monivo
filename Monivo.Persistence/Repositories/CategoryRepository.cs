using Microsoft.EntityFrameworkCore;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;
using Monivo.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monivo.Persistence.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private readonly MonivoDbContext _context;

        public CategoryRepository(MonivoDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetByUserIdAsync(int userId)
        {
            return await _context.Categories
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
        public async Task<Category?> GetByIdAndUserIdAsync(int id, int userId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }
    }
}
