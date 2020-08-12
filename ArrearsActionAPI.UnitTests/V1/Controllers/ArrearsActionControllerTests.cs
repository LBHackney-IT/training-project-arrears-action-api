using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ArrearsActionAPI.V1.Controllers;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Usecases;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ArrearsActionAPI.V1.Validators;
using ArrearsActionAPI.V1.Errors;

namespace ArrearsActionAPI.UnitTests.V1.Controllers
{
    [TestFixture]
    public class ArrearsActionControllerTests
    {
        private ArrearsActionsController _controllerUnderTest;
        private Mock<IArrearsActionUsecase> _mockUsecase;
        private Mock<IFValidator<GetAractionsByPropRefRequest>> _mockGetByPropRefValidator;

        [SetUp]
        public void Setup()
        {
            _mockUsecase = new Mock<IArrearsActionUsecase>();
            _mockGetByPropRefValidator = new Mock<IFValidator<GetAractionsByPropRefRequest>>();
            _controllerUnderTest = new ArrearsActionsController(_mockUsecase.Object, _mockGetByPropRefValidator.Object);
        }

        #region Usecase - Controller tests

        [Test]
        public void Given_a_valid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_calls_the_usecase()
        {
            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            // act
            _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            _mockUsecase.Verify(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }

        [Test]
        public void Given_an_invalid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_does_not_call_the_usecase()
        {
            // arrange
            var failed_validation_result = TestHelper.Generate_FailedValidationResult();
            _mockGetByPropRefValidator.Setup(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>())).Returns(failed_validation_result);

            // act
            _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            _mockUsecase.Verify(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>()), Times.Never);
        }

        [Test]
        public void Given_a_valid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_calls_the_usecase_with_the_same_request_object()
        {
            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockUsecase.Verify(u => u.GetByPropRef(It.Is<GetAractionsByPropRefRequest>(r => r == request)), Times.Once);
        }

        [Test]
        public void Given_a_successful_request__When_usecase_returns_its_result__Then_GetAractionsByPropRef_ArrearsActionController_wraps_it_up_And_returns_that_result_within_a_response_object()
        {
            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);
            var usecase_result = new GetAractionsByPropRefResponse(TestHelper.Generate_GetAractionsByPropRefRequest(), TestHelper.Generate_ListOfArrearsActions());

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Returns(usecase_result);

            // act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            var response_value = (response as ObjectResult)?.Value;
            Assert.AreSame(usecase_result, response_value);
        }

        #endregion

        #region Validator - Controller tests

        [Test]
        public void Given_a_request_When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_calls_GetAractionsByPropRefRequestValidator()
        {
            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            // act
            _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            _mockGetByPropRefValidator.Verify(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }

        [Test]
        public void Given_a_request_When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_calls_GetAractionsByPropRefRequestValidator_with_the_same_request_object()
        {

            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockGetByPropRefValidator.Verify(v => v.Validate(It.Is<GetAractionsByPropRefRequest>(r => r == request)), Times.Once);
        }

        #endregion

        #region Responses - Controller tests

        [Test]
        public void Given_a_successful_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_returns_a_200_Ok_response()
        {
            // arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            // act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            var response_type = response as ObjectResult;
            Assert.NotNull(response_type);
            Assert.IsInstanceOf<OkObjectResult>(response_type);

            var response_code = response_type.StatusCode;
            Assert.AreEqual(200, response_code);
        }

        [Test]
        public void Given_an_invalid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_returns_a_400_BadRequest_response()
        {
            // arrange
            var failed_validation_result = TestHelper.Generate_FailedValidationResult();
            _mockGetByPropRefValidator.Setup(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>())).Returns(failed_validation_result);

            // act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            // assert
            var response_type = response as ObjectResult;
            Assert.NotNull(response_type);
            Assert.IsInstanceOf<BadRequestObjectResult>(response_type);

            var response_code = response_type.StatusCode;
            Assert.AreEqual(400, response_code);
        }

        [Test]
        public void Given_an_invalid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_returned_BadRequestObjectResult_contains_correctly_formatted_Error_response()
        {
            //arrange
            var failed_validation_result = TestHelper.Generate_FailedValidationResult();
            _mockGetByPropRefValidator.Setup(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>())).Returns(failed_validation_result);    //mock validator says that it has found errors

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_value = (response as ObjectResult).Value;
            var error_response = response_value as ErrorResponse;

            //assert
            Assert.NotNull(response_value);

            Assert.IsInstanceOf<ErrorResponse>(response_value);
            Assert.NotNull(response_value);
        }

        [Test]
        public void Given_an_invalid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_the_returned_Error_response_contains_a_list_of_errors() // no need to test the actual messages here, because that conversion process is tested in the ErrorFormatter tests
        {
            //arrange
            var failed_validation_result = TestHelper.Generate_FailedValidationResult();
            var validation_errors = failed_validation_result.Errors.ToList();
            _mockGetByPropRefValidator.Setup(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>())).Returns(failed_validation_result);    //mock validator says that it has found errors

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_value = (response as ObjectResult).Value;
            var error_response = response_value as ErrorResponse;
            var response_errors = error_response.Errors;

            //assert
            Assert.NotNull(response_errors);
            Assert.AreEqual(validation_errors.Count, response_errors.Count);
            validation_errors.ForEach(
                e => Assert.True(
                    response_errors.Any(re => re.Contains(e.ErrorMessage))
                    ));
        }

        [Test]
        public void Given_a_NotFoundException_exception_is_thrown_within_deeper_flow__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_404_status_code_response()
        {
            //Arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            var not_found_exception = new NotFoundException();

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(not_found_exception); // doesn't matter where so long it's not within the controller

            //Act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_result = (ObjectResult)response;

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response_result);
            Assert.AreEqual(404, response_result.StatusCode);
        }

        [Test]
        public void Given_a_NotFoundException_exception_is_thrown_within_deeper_flow__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_an_Error_response()
        {
            //Arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            var not_found_exception = new NotFoundException();

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(not_found_exception);

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_result = response as ObjectResult;
            var response_content = response_result.Value;

            //assert
            Assert.NotNull(response);
            Assert.NotNull(response_result);
            Assert.IsInstanceOf<ErrorResponse>(response_content);
            Assert.NotNull(response_content);
        }

        [Test]
        public void Given_a_NotFoundException_exception_is_thrown_within_deeper_flow__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_corresponding_error_message()
        {
            //arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);
            var random_expected_error_message = ErrorThrowerHelper.Generate_Error().Message;
            var not_found_exception = new NotFoundException(random_expected_error_message);
            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(not_found_exception);

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            var response_result = response as ObjectResult;
            var response_content = response_result.Value as ErrorResponse;

            //assert

            Assert.NotNull(response_content);

            var actual_error_message = response_content.Errors.FirstOrDefault();

            Assert.AreEqual(random_expected_error_message, actual_error_message);
        }

        [Test]
        public void Given_an_unexpected_exception_is_thrown_in_the_usecase__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_500_status_code_response()
        {
            //Arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            var random_expected_exception = ErrorThrowerHelper.Generate_Error();

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(random_expected_exception);

            //Act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_result = (ObjectResult)response;

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response_result);
            Assert.AreEqual(500, response_result.StatusCode);
        }

        [Test]
        public void Given_an_unexpected_exception_is_thrown_in_the_GetByPropRefValidator__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_500_status_code_response()
        {
            //Arrange
            var random_expected_exception = ErrorThrowerHelper.Generate_Error();

            _mockGetByPropRefValidator.Setup(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>())).Throws(random_expected_exception);

            //Act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_result = (ObjectResult)response;

            //Assert
            Assert.NotNull(response);
            Assert.NotNull(response_result);
            Assert.AreEqual(500, response_result.StatusCode);
        }

        [Test]
        public void Given_an_unexpected_exception_is_thrown__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_an_Error_response()
        {
            //arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            var random_expected_exception = ErrorThrowerHelper.Generate_Error();

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(random_expected_exception);

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);
            var response_result = response as ObjectResult;
            var response_content = response_result.Value;

            //assert
            Assert.NotNull(response);
            Assert.NotNull(response_result);
            Assert.IsInstanceOf<ErrorResponse>(response_content);
            Assert.NotNull(response_content);
        }

        [Test]
        public void Given_a_regular_unexpected_exception_is_thrown__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_corresponding_error_message()
        {
            //arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            (Exception random_expected_exception, List<string> expected_error_messages) = ErrorThrowerHelper
                .Generate_ExceptionAndCorrespondinErrorMessages(ErrorThrowerHelper.ErrorThrowerOptions.SimpleErrors);

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(random_expected_exception);

            var expected_error_message = expected_error_messages[0];

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            var response_result = response as ObjectResult;
            var response_content = response_result.Value as ErrorResponse;

            //assert

            Assert.NotNull(response_content);
            Assert.AreEqual(expected_error_messages.Count, response_content.Errors.Count);
            Assert.AreEqual(1, response_content.Errors.Count);

            var actual_error_message = response_content.Errors[0];

            Assert.AreEqual(expected_error_message, actual_error_message);
        }

        [Test]
        public void Given_a_nested_unexpected_exception_is_thrown__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_returns_corresponding_error_message__And_inner_error_message()
        {
            //arrange
            TestHelper.SetUp_MockValidatorSuccessResponse(_mockGetByPropRefValidator);

            (Exception random_expected_exception, List<string> expected_error_messages) = ErrorThrowerHelper
                .Generate_ExceptionAndCorrespondinErrorMessages(ErrorThrowerHelper.ErrorThrowerOptions.InnerErrors);

            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Throws(random_expected_exception);

            var expected_error_message = expected_error_messages[0];
            var expected_inner_error_message = expected_error_messages[1];

            //act
            var response = _controllerUnderTest.GetAractionsByPropRef(null);

            var response_result = response as ObjectResult;
            var response_content = response_result.Value as ErrorResponse;

            //assert

            Assert.NotNull(response_content);
            Assert.AreEqual(expected_error_messages.Count, response_content.Errors.Count);
            Assert.AreEqual(2, response_content.Errors.Count);

            var actual_error_message = response_content.Errors[0];
            var actual_inner_error_message = response_content.Errors[1];

            Assert.AreEqual(expected_error_message, actual_error_message);
            Assert.AreEqual(expected_inner_error_message, actual_inner_error_message);
        }

        #endregion
    }
}
