using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Gateways
{
    public class ArrearsActionGateway : IArrearsActionGateway
    {
        public List<ArrearsAction> GetByPropRef(string prop_ref)
        {
            throw new NotImplementedException();
        }
    }
}
