using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Domain;
using Bogus;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FV = FluentValidation.Results;

namespace ArrearsActionAPI.UnitTests
{
    public static class TestHelper
    {
        private static Faker _faker = new Faker();

        public static GetAractionsByPropRefRequest Generate_GetAractionsByPropRefRequest()
        {
            var rand_prop_ref = _faker.Random.Hash().ToString();
            return new GetAractionsByPropRefRequest() {
                PropertyRef = rand_prop_ref
            };
        }

        private static ArrearsAction Generate_ArrearsAction() //TODO: Generate with proper fields
        {
            return new ArrearsAction();
        }

        public static List<ArrearsAction> Generate_ListOfArrearsActions() //Messing about here, IRL would do a for loop.
        {
            return Enumerable.Range(0, _faker.Random.Int(1, 10))
                .Aggregate(
                    new List<ArrearsAction>(), 
                    (acc, _) => {
                        acc.Add(Generate_ArrearsAction());
                        return acc;
                    }
                );
        }

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
    }
}
