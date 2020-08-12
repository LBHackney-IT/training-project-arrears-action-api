using ArrearsActionAPI.V1.Boundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArrearsActionAPI.V1.Gateways;

namespace ArrearsActionAPI.V1.Usecases
{
    public class ArrearsActionUsecase : IArrearsActionUsecase
    {
        private readonly IArrearsActionGateway _arrearsActionGateway;

        public ArrearsActionUsecase(IArrearsActionGateway arrearsActionGateway)
        {
            _arrearsActionGateway = arrearsActionGateway;
        }

        public GetAractionsByPropRefResponse GetByPropRef(GetAractionsByPropRefRequest request)
        {
            var gateway_result = _arrearsActionGateway.GetByPropRef(request.PropertyRef);

            return new GetAractionsByPropRefResponse(request, gateway_result);
        }
    }
}
