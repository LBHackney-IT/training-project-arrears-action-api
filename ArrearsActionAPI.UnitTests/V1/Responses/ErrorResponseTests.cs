using System.Collections.Generic;
using System.Linq;
using Bogus;
using NUnit.Framework;
using ArrearsActionAPI.V1.Errors;

namespace ArrearsActionAPI.UnitTests.V1.Errors
{
    [TestFixture]
    public class ErrorResponseTests
    {
        private Faker _faker = new Faker();

        [Test]
        public void When_ErrorResponse_constructor_is_called__Then_it_initializes_status_parameter_to_fail()
        {
            //act
            var error_response = new ErrorResponse();

            //assert
            Assert.AreEqual(error_response.Status, "fail");
        }

        [Test]
        public void Given_no_parameters__When_ErrorResponse_constructor_is_called__Then_it_initializes_errors_parameter_to_empty_list()
        {
            //act
            var error_response = new ErrorResponse();

            //assert
            Assert.NotNull(error_response.Errors);
            Assert.Zero(error_response.Errors.Count);
        }

        [Test]
        public void Given_a_list_of_error_strings__When_ErrorResponse_constructor_is_called_Then_it_initializes_errors_parameter_to_passed_in_list_of_errors()
        {
            //arrange
            var expected_list_of_errors = new List<string>();

            for (int i = _faker.Random.Int(1, 10); i > 0; i--)
                expected_list_of_errors.Add(_faker.Random.Hash());

            //act
            var error_response = new ErrorResponse(expected_list_of_errors);
            var actual_list_of_errors = error_response.Errors;

            //assert
            Assert.NotNull(actual_list_of_errors);
            Assert.AreSame(expected_list_of_errors, actual_list_of_errors); //they should have the same obj reference
        }

        [Test]
        public void Given_any_number_of_error_string_parameters__When_ErrorResponse_constructor_is_called__Then_it_initializes_errors_parameter_to_a_list_of_error_strings_corresponding_to_passed_in_parameters()
        {
            //act
            var single_parameter_error_response = new ErrorResponse(_faker.Random.Word());
            var four_parameter_error_response = new ErrorResponse(_faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word());
            var seven_parameter_error_response = new ErrorResponse(_faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word(), _faker.Random.Word());

            //assert
            Assert.AreEqual(1, single_parameter_error_response.Errors.Count);
            Assert.AreEqual(4, four_parameter_error_response.Errors.Count);
            Assert.AreEqual(7, seven_parameter_error_response.Errors.Count);
        }

        [Test]
        public void Given_a_list_of_validation_failures__When_ErrorResponse_constructor_is_called__Then_it_initializes_errors_parameter_to_a_list_of_error_messages()
        {
            //arrange
            var validation_failures_list = TestHelper.Generate_AListOfValidationFailures();

            //act
            var error_response = new ErrorResponse(validation_failures_list);

            //assert
            Assert.IsInstanceOf<List<string>>(error_response.Errors);
            Assert.AreEqual(validation_failures_list.Count, error_response.Errors.Count);
        }
    }
}
