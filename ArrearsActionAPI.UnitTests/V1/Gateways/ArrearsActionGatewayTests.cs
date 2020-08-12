using ArrearsActionAPI.V1.Gateways;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using ArrearsActionAPI.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ArrearsActionAPI.V1.Errors;

namespace ArrearsActionAPI.UnitTests.V1.Gateways
{
    [TestFixture]
    class ArrearsActionGatewayTests : DatabaseTestsSetup
    {
        private IArrearsActionGateway _gatewayUnderTest;

        [SetUp]
        public void Setup()
        {
            _gatewayUnderTest = new ArrearsActionGateway(_coreHousingContext);
        }

        [Test]
        public void Given_the_database_contains_no_TenancyAgreement_records__When_ArrearsActionGateway_GetByPropRef_method_is_called__Then_it_throws_a_NotFoundException() //no records
        {
            // arrange
            var prop_ref = TestHelper.Generate_PropRef();

            // act
            TestDelegate test_delegate = () => _gatewayUnderTest.GetByPropRef(prop_ref);

            // assert
            Assert.Zero(_coreHousingContext.TenancyAgreementEntities.Count());

            var ex = Assert.Throws<NotFoundException>(test_delegate);
            
            Assert.AreEqual($"Tenancy agreement resource was not found.", ex.Message);
        }

        [Test]
        public void Given_the_database_contains_no_Matching_TenancyAgreement_records__When_ArrearsActionGateway_GetByPropRef_method_is_called__Then_it_throws_a_NotFoundException() // no existing match
        {
            // arrange
            var prop_ref = TestHelper.Generate_PropRef();

            var tenancy_agreement_list = TestHelper.Generate_Many_TenancyAgreementEntity(10);
            _coreHousingContext.TenancyAgreementEntities.AddRange(tenancy_agreement_list);
            _coreHousingContext.SaveChanges();

            // act
            TestDelegate test_delegate = () => _gatewayUnderTest.GetByPropRef(prop_ref);

            // assert
            Assert.Zero(_coreHousingContext.TenancyAgreementEntities.Count());

            var ex = Assert.Throws<NotFoundException>(test_delegate);

            Assert.AreEqual($"Tenancy agreement resource was not found.", ex.Message);
        }

        [Test]
        public void Given_the_database_contains_a_matching_TenancyAgreement_record___But_it_does_not_contain_any_ArrearsActions__When_ArrearsActionGateway_GetByPropRef_method_is_called__Then_it_returns_an_empty_collection()
        {
            // arrange
            var prop_ref = TestHelper.Generate_PropRef();
            var tenancy_agreement_1 = Generate_and_AddTenancyAgreementEntityToDatabase(prop_ref);

            // act
            var gateway_response = _gatewayUnderTest.GetByPropRef(prop_ref);

            // assert
            Assert.Zero(_coreHousingContext.ArrearsActionEntities.Count());
            Assert.NotNull(gateway_response);
            Assert.Zero(gateway_response.Count);
        }

        [Test]
        public void Given_the_database_contains_a_matching_TenancyAgreement_record___But_it_does_not_match_any_Existing_ArrearsActions__When_ArrearsActionGateway_GetByPropRef_method_is_called__Then_it_returns_an_empty_collection()
        {
            // arrange
            var prop_ref = TestHelper.Generate_PropRef();
            var tenancy_agreement_1 = Generate_and_AddTenancyAgreementEntityToDatabase(prop_ref);
            
            var arrears_action_list = TestHelper.Generate_Many_ArrearsActionEntity(10);
            _coreHousingContext.ArrearsActionEntities.AddRange(arrears_action_list);
            _coreHousingContext.SaveChanges();

            // act
            var gateway_response = _gatewayUnderTest.GetByPropRef(prop_ref);

            // assert
            Assert.NotNull(gateway_response);
            Assert.Zero(gateway_response.Count);
        }

        [Test]
        public void Given_the_database_contains_a_matching_TenancyAgreement_record__And_it_matches_some_Existing_ArrearsActions__When_ArrearsActionGateway_GetByPropRef_method_is_called__Then_it_returns_just_the_matching_results()
        {
            // arrange
            var prop_ref = TestHelper.Generate_PropRef();
            var tenancy_agreement_1 = Generate_and_AddTenancyAgreementEntityToDatabase(prop_ref);
            Generate_and_AddPairedArrearsActions(tenancy_agreement_1.tag_ref, 10);

            var tenancy_agreement_2 = Generate_and_AddTenancyAgreementEntityToDatabase();
            Generate_and_AddPairedArrearsActions(tenancy_agreement_2.tag_ref, 20);

            // act
            var gateway_response = _gatewayUnderTest.GetByPropRef(prop_ref);

            // assert
            Assert.NotNull(gateway_response);
            Assert.Equals(10, gateway_response.Count);
            Assert.True(gateway_response.All(a => a.TenancyAgreementRef == tenancy_agreement_1.tag_ref));
        }


        // More helper methods

        private void Generate_and_AddPairedArrearsActions(string tenanagree_ref, int quantity)
        {
            var arrears_action_list = TestHelper.Generate_Many_ArrearsActionEntity(10);
            arrears_action_list.ForEach(a => a.tag_ref = tenanagree_ref);
            _coreHousingContext.ArrearsActionEntities.AddRange(arrears_action_list);
            _coreHousingContext.SaveChanges();
        }

        private TenancyAgreementEntity Generate_and_AddTenancyAgreementEntityToDatabase(string property_ref = null, string tenagree_ref = null)
        {
            var tenancy_agreement = TestHelper.Generate_TenancyAgreementEntity();
            tenancy_agreement.tag_ref = tenagree_ref ?? tenancy_agreement.tag_ref;
            tenancy_agreement.prop_ref = property_ref ?? tenancy_agreement.prop_ref;

            _coreHousingContext.Add(tenancy_agreement);
            _coreHousingContext.SaveChanges();
            return tenancy_agreement;
        }

        private ArrearsActionEntity Generate_and_AddArrearsActionEntityToDatabase(string tenagree_ref = null) //TODO: Improve as generic
        {
            var arrears_action = TestHelper.Generate_ArrearsActionEntity();
            arrears_action.tag_ref = tenagree_ref ?? arrears_action.tag_ref;

            _coreHousingContext.Add(arrears_action);
            _coreHousingContext.SaveChanges();
            return arrears_action;
        }
    }
}
