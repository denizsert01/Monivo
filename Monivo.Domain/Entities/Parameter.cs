using Monivo.Domain.Common;

namespace Monivo.Domain.Entities
{
    public class Parameter : BaseEntity
    {
        public string ParamType { get; set; }

        public string ParamCode { get; set; }

        public string ParamValue { get; set; }
        public string ParamDescription { get; set; }

        public bool IsActive { get; set; }

    }
}
