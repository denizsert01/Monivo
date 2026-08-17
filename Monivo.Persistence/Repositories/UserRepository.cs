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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MonivoDbContext _context;

        public UserRepository(MonivoDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
