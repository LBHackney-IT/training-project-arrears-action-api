using ArrearsActionAPI.V1.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrearsActionAPI.UnitTests.V1.Infrastructure
{
    [TestFixture]
    public class CoreHousingContextTests : DatabaseTestsSetup
    {
        [Test]
        public void Can_get_ArrearsAction_database_entity()
        {
            var databaseEntity = TestHelper.Generate_ArrearsActionEntity();

            _coreHousingContext.Add<ArrearsActionEntity>(databaseEntity);
            _coreHousingContext.SaveChanges();

            var result = _coreHousingContext.ArrearsActionEntities.ToList().FirstOrDefault();

            Assert.AreEqual(result, databaseEntity);
        }

        [Test]
        public void Can_get_TenancyAgreement_database_entity()
        {
            var databaseEntity = TestHelper.Generate_TenancyAgreementEntity();

            _coreHousingContext.Add<TenancyAgreementEntity>(databaseEntity);
            _coreHousingContext.SaveChanges();

            var result = _coreHousingContext.TenancyAgreementEntities.ToList().FirstOrDefault();

            Assert.AreEqual(result, databaseEntity);
        }
    }
}
