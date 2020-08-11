using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArrearsActionAPI.V1.Infrastructure
{
    public class CoreHousingContext : DbContext
    {
        public CoreHousingContext(DbContextOptions options) : base(options) { }

        public DbSet<ArrearsActionEntity> ArrearsActionEntities { get; set; }
        public DbSet<TenancyAgreementEntity> TenancyAgreementEntities { get; set; }
    }
}
