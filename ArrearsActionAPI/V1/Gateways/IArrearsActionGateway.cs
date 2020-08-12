using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using System.Collections.Generic;

namespace ArrearsActionAPI.V1.Gateways
{
    public interface IArrearsActionGateway
    {
        List<ArrearsAction> GetByPropRef(string prop_ref);
    }
}