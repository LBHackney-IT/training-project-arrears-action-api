using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Validators;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.TestHelper;

namespace ArrearsActionAPI.UnitTests.V1.Validators
{
    [TestFixture]
    class GetAractionsByPropRefRequestValidatorTests
    {
        private GetAractionsByPropRefRequestValidator _validatorUnderTest;

        [SetUp]
        public void Setup()
        {
            _validatorUnderTest = new GetAractionsByPropRefRequestValidator();
        }

        #region Validity Checks

        [Test]
        public void Given_a_request_with_an_empty_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_an_error()
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = "" };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request);
        }

        [Test]
        public void Given_a_request_with_a_null_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_an_error()
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = null };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request);
        }

        [Test]
        public void Given_a_request_with_a_valid_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_no_error()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act, assert
            _validatorUnderTest.ShouldNotHaveValidationErrorFor(r => r.PropertyRef, request);
        }

        #endregion

        #region Error Message Checks

        [Test]
        public void Given_a_request_with_an_empty_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_correct_error_message()
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = "" };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request).WithErrorMessage("PropertyRef must not be empty.");
        }

        [Test]
        public void Given_a_request_with_a_null_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_correct_error_message()
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = null };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request).WithErrorMessage("PropertyRef must be provided.");
        }

        [Test]
        public void Given_a_request_with_a_null_or_empty_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_only_one_corresponding_error_message()
        {
            // arrange
            var request_empty = new GetAractionsByPropRefRequest() { PropertyRef = "" };
            var request_null = new GetAractionsByPropRefRequest() { PropertyRef = null };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request_empty)
                .WithErrorMessage("PropertyRef must not be empty.")
                .WithoutErrorMessage("PropertyRef must be provided.");

            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request_null)
                .WithErrorMessage("PropertyRef must be provided.")
                .WithoutErrorMessage("PropertyRef must not be empty.");
        }

        #endregion
    }
}
