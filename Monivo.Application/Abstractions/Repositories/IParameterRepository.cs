
using Monivo.Domain.Entities;

namespace Monivo.Application.Abstractions.Repositories
{
    public interface IParameterRepository : IRepository<Parameter>
    {
        Task<List<Parameter>> GetByTypeAsync(string paramType);
    }
}
