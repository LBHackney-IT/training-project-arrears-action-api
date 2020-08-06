using ArrearsActionAPI.V1.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Boundary
{
    public class GetAractionsByPropRefResponse
    {
        public GetAractionsByPropRefRequest Request { get; set; }
        public List<ArrearsAction> ArrearsActions { get; set; }
        public DateTime GeneratedAt { get; set; }

        public GetAractionsByPropRefResponse(GetAractionsByPropRefRequest request, List<ArrearsAction> result, DateTime generated_at)
        {
            Request = request;
            ArrearsActions = result;
            GeneratedAt = generated_at;
        }
    }
}
