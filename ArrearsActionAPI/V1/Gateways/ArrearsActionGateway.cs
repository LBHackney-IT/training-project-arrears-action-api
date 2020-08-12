using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using ArrearsActionAPI.V1.Errors;
using ArrearsActionAPI.V1.Factories;
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
            var tenancy_refs = _coreHousingContext.TenancyAgreementEntities.Where(t => t.prop_ref == prop_ref).Select(t => t.tag_ref).ToList();

            if (tenancy_refs.Count.Equals(0))
                throw new NotFoundException($"Tenancy agreement resource was not found.");

            var aractions = _coreHousingContext.ArrearsActionEntities.Where(a => tenancy_refs.Contains(a.tag_ref)).ToList();

            return aractions.ToDomain();
        }
    }
}
