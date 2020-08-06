using ArrearsActionAPI.V1.Boundary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Usecases
{
    public interface IArrearsActionUsecase
    {
        GetAractionsByPropRefResponse GetByPropRef(GetAractionsByPropRefRequest request);
    }
}
