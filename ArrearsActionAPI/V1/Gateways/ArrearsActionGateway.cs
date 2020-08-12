using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using ArrearsActionAPI.V1.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Gateways
{
    public class ArrearsActionGateway : IArrearsActionGateway
    {
        private readonly CoreHousingContext _coreHousingContext;

        public ArrearsActionGateway(CoreHousingContext coreHousingContext)
        {
            _coreHousingContext = coreHousingContext;
        }

        public List<ArrearsAction> GetByPropRef(string prop_ref)
        {
            throw new NotImplementedException();
        }
    }
}
