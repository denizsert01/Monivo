using MediatR;
using Monivo.Application.Abstractions.Repositories;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Parameters.Queries.GetByType
{
    public class GetParametersByTypeQueryHandler
         : IRequestHandler<GetParametersByTypeQuery, List<Parameter>>
    {
        private readonly IParameterRepository _parameterRepository;

        public GetParametersByTypeQueryHandler(
            IParameterRepository parameterRepository)
        {
            _parameterRepository = parameterRepository;
        }

        public async Task<List<Parameter>> Handle(
            GetParametersByTypeQuery request,
            CancellationToken cancellationToken)
        {
            return await _parameterRepository
                .GetByTypeAsync(request.ParamType);
        }
    }
}
