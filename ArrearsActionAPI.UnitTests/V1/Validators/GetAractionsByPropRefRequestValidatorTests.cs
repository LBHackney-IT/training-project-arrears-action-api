using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Validators;
using NUnit.Framework;
using FluentValidation.TestHelper;
using ArrearsActionAPI.V1.Helpers;

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

        [TestCase("")]
        [TestCase(" ")]
        public void Given_a_request_with_an_empty_or_whitespace_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_an_error(string test_prop_ref)
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = test_prop_ref };

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

        [TestCase("")]
        [TestCase(" ")]
        public void Given_a_request_with_an_empty_or_whitespace_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_correct_error_message(string test_prop_ref)
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = test_prop_ref };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request).WithErrorMessage(ErrorMessagesFormatter.FieldIsWhiteSpaceOrEmpty("PropertyRef"));
        }

        [Test]
        public void Given_a_request_with_a_null_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_correct_error_message()
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = null };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request).WithErrorMessage(ErrorMessagesFormatter.FieldIsNullMessage("PropertyRef"));
        }

        [Test]
        public void Given_a_request_with_a_null_or_empty_or_whitespace_propertyRef__When_GetAractionsByPropRefRequestValidator_is_called__Then_it_returns_only_one_corresponding_error_message()
        {
            // arrange
            var request_empty = new GetAractionsByPropRefRequest() { PropertyRef = "" };
            var request_whitespace = new GetAractionsByPropRefRequest() { PropertyRef = " " };
            var request_null = new GetAractionsByPropRefRequest() { PropertyRef = null };

            // act, assert
            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request_empty)
                .WithErrorMessage(ErrorMessagesFormatter.FieldIsWhiteSpaceOrEmpty("PropertyRef"))
                .WithoutErrorMessage(ErrorMessagesFormatter.FieldIsNullMessage("PropertyRef"));

            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request_whitespace)
                .WithErrorMessage(ErrorMessagesFormatter.FieldIsWhiteSpaceOrEmpty("PropertyRef"))
                .WithoutErrorMessage(ErrorMessagesFormatter.FieldIsNullMessage("PropertyRef"));

            _validatorUnderTest.ShouldHaveValidationErrorFor(r => r.PropertyRef, request_null)
                .WithErrorMessage(ErrorMessagesFormatter.FieldIsNullMessage("PropertyRef"))
                .WithoutErrorMessage(ErrorMessagesFormatter.FieldIsWhiteSpaceOrEmpty("PropertyRef"));
        }

        #endregion
    }
}
