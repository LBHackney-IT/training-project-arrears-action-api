using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using Bogus;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FV = FluentValidation.Results;
using Moq;
using FluentValidation;
using ArrearsActionAPI.V1.Validators;
using ArrearsActionAPI.V1.Infrastructure;

namespace ArrearsActionAPI.UnitTests
{
    public static class TestHelper
    {
        private static Faker _faker = new Faker();

        private static Faker<ArrearsActionEntity> _fakerArrearsActionEntity
            = new Faker<ArrearsActionEntity>()
            .RuleFor(o => o.tag_ref, f => f.Random.AlphaNumeric(11))
            .RuleFor(o => o.action_set, f => f.Random.Int(0))
            .RuleFor(o => o.action_no, f => f.Random.Int(0))
            .RuleFor(o => o.action_code, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.action_date, f => f.Date.Past())
            .RuleFor(o => o.action_balance, f => f.Random.Decimal(0, 1000))
            .RuleFor(o => o.action_comment, f => f.Random.AlphaNumeric(5))
            .RuleFor(o => o.username, f => f.Random.AlphaNumeric(f.Random.Int(7, 40)))
            .RuleFor(o => o.comm_only, f => f.Random.Bool())
            .RuleFor(o => o.ole_obj, f => f.Random.Bytes(f.Random.Int(1, 8)))
            .RuleFor(o => o.araction_sid, f => f.Random.Int(0))
            .RuleFor(o => o.action_deferred, f => f.Random.Bool())
            .RuleFor(o => o.deferred_until, f => f.Date.Past())
            .RuleFor(o => o.deferral_reason, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.severity_level, f => f.Random.Int(0, 9))
            .RuleFor(o => o.action_nr_balance, f => f.Random.Decimal(0, 10000))
            .RuleFor(o => o.action_type, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.act_status, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.action_cat, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.action_subno, f => f.Random.Int(0))
            .RuleFor(o => o.action_subcode, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.action_process_no, f => f.Random.Int(0))
            .RuleFor(o => o.notice_sid, f => f.Random.Int(0))
            .RuleFor(o => o.courtord_sid, f => f.Random.Int(0))
            .RuleFor(o => o.warrant_sid, f => f.Random.Int(0))
            .RuleFor(o => o.action_doc_no, f => f.Random.Int(0))
            .RuleFor(o => o.tstamp, f => f.Random.Bytes(8))
            .RuleFor(o => o.comp_avail, f => f.Random.AlphaNumeric(f.Random.Int(30, 200)))
            .RuleFor(o => o.comp_display, f => f.Random.AlphaNumeric(f.Random.Int(30, 200)))
            .RuleFor(o => o.u_saff_araction_ref, f => f.Random.AlphaNumeric(f.Random.Int(5, 30)));

        private static Faker<TenancyAgreementEntity> _fakerTenancyAgreementEntity
            = new Faker<TenancyAgreementEntity>()
            .RuleFor(o => o.tag_ref, f => f.Random.AlphaNumeric(11))
            .RuleFor(o => o.prop_ref, f => f.Random.AlphaNumeric(12))
            .RuleFor(o => o.house_ref, f => f.Random.AlphaNumeric(10))
            .RuleFor(o => o.cot, f => f.Date.Past())
            .RuleFor(o => o.eot, f => f.Date.Future())
            .RuleFor(o => o.spec_terms, f => f.Random.Bool())
            .RuleFor(o => o.other_accounts, f => f.Random.Bool())
            .RuleFor(o => o.active, f => f.Random.Bool())
            .RuleFor(o => o.present, f => f.Random.Bool())
            .RuleFor(o => o.terminated, f => f.Random.Bool())
            .RuleFor(o => o.free_active, f => f.Random.Bool())
            .RuleFor(o => o.nop, f => f.Random.Bool())
            .RuleFor(o => o.additional_debit, f => f.Random.Bool())
            .RuleFor(o => o.fd_charge, f => f.Random.Bool())
            .RuleFor(o => o.receiptcard, f => f.Random.Bool())
            .RuleFor(o => o.nosp, f => f.Random.Bool())
            .RuleFor(o => o.ntq, f => f.Random.Bool())
            .RuleFor(o => o.eviction, f => f.Random.Bool())
            .RuleFor(o => o.committee, f => f.Random.Bool())
            .RuleFor(o => o.suppossorder, f => f.Random.Bool())
            .RuleFor(o => o.possorder, f => f.Random.Bool())
            .RuleFor(o => o.courtapp, f => f.Random.Bool())
            .RuleFor(o => o.open_item, f => f.Random.Bool())
            .RuleFor(o => o.potentialenddate, f => f.Date.Future())
            .RuleFor(o => o.u_payment_expected, f => f.Random.AlphaNumeric(3))
            .RuleFor(o => o.dtstamp, f => f.Date.Past())
            .RuleFor(o => o.intro_date, f => f.Date.Past())
            .RuleFor(o => o.intro_ext_date, f => f.Date.Past());

        // I'm not convinced that this object generation feature is worth it. All these chained
        // extension methods are making my IDE lag from all the type and syntax checking.
        // (And I checked it - once I remove this code, it all goes back to normal)
        // I don't see much benefit over the good old initializing the object while new'ing it up either.
        // The only thing this giant thing does - it looks cool, and makes IDE laggy. That's it.
        // Used alphanumeric, because Faker String method generates weird control chars.

        #region Requests

        public static GetAractionsByPropRefRequest Generate_GetAractionsByPropRefRequest()
        {
            var rand_prop_ref = Generate_PropRef();
            return new GetAractionsByPropRefRequest()
            {
                PropertyRef = rand_prop_ref
            };
        }

        public static string Generate_PropRef()
        {
            return _faker.Random.Hash().ToString();
        }

        #endregion

        #region Domain

        private static ArrearsAction Generate_ArrearsAction() //TODO: Generate with proper fields
        {
            return new ArrearsAction();
        }

        public static List<ArrearsAction> Generate_ListOfArrearsActions() //Messing about here, IRL would do a for loop.
        {
            return Enumerable.Range(0, _faker.Random.Int(1, 10))
                .Aggregate(
                    new List<ArrearsAction>(),
                    (acc, _) =>
                    {
                        acc.Add(Generate_ArrearsAction());
                        return acc;
                    }
                );
        } 

        #endregion

        #region Fake Validation Results

        public static List<ValidationFailure> Generate_AListOfValidationFailures()
        {
            int errorCount = _faker.Random.Int(1, 10);                                                                                                  //simulate from 1 to 10 validation errors (triangulation).
            var validationErrorList = new List<ValidationFailure>();                                                                                    //this list will be used as constructor argument for 'ValidationResult'.
            for (int i = errorCount; i > 0; i--) { validationErrorList.Add(new ValidationFailure(_faker.Random.Word(), _faker.Random.Word())); }        //generate from 1 to 10 fake validation errors. Single line for-loop so that it wouldn't distract from what's key in this test.

            return validationErrorList;
        }

        public static FV.ValidationResult Generate_FailedValidationResult()
        {
            var validationErrorList = Generate_AListOfValidationFailures();
            return new FV.ValidationResult(validationErrorList);                                                                                        //Need to create ValidationResult so that I could setup Validator mock to return it upon '.Validate()' call. Also this is the only place where it's possible to manipulate the validation result - You can only make the validation result invalid by inserting a list of validation errors as a parameter through a constructor. The boolean '.IsValid' comes from expression 'IsValid => Errors.Count == 0;', so it can't be set manually.
        }

        public static FV.ValidationResult Generate_SuccessValidationResult()
        {
            return new FV.ValidationResult();                                                                                                           //This is a success, because no validation failures were passed into the constructor. The boolean '.IsValid' comes from expression 'IsValid => Errors.Count == 0;', so it can't be set manually.
        }

        #endregion


        public static void SetUp_MockValidatorSuccessResponse<ValidatorRequestType>(Mock<IFValidator<ValidatorRequestType>> mock_validator)
        where ValidatorRequestType : class
        {
            mock_validator.Setup(v => v.Validate(It.IsAny<ValidatorRequestType>())).Returns(Generate_SuccessValidationResult());
        }

        #region EF Core Entities

        public static ArrearsActionEntity Generate_ArrearsActionEntity()
        {
            return _fakerArrearsActionEntity.Generate();
        }

        public static List<ArrearsActionEntity> Generate_Many_ArrearsActionEntity(int quantity = 1)
        {
            return _fakerArrearsActionEntity.Generate(quantity);
        }

        public static TenancyAgreementEntity Generate_TenancyAgreementEntity()
        {
            return _fakerTenancyAgreementEntity.Generate();
        }

        public static List<TenancyAgreementEntity> Generate_Many_TenancyAgreementEntity(int quantity = 1)
        {
            return _fakerTenancyAgreementEntity.Generate(quantity);
        }

        #endregion
    }
}
