using MediatR;
using Monivo.Domain.Entities;

namespace Monivo.Application.Features.Parameters.Queries.GetByType
{
    public class GetParametersByTypeQuery : IRequest<List<Parameter>>
    {
        public string ParamType { get; set; }

        public GetParametersByTypeQuery(string paramType)
        {
            ParamType = paramType;
        }
    }
}
