﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ArrearsActionAPI.V1.Controllers;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Usecases;
using Moq;
using Microsoft.AspNetCore.Mvc;
using ArrearsActionAPI.V1.Validators;

namespace ArrearsActionAPI.UnitTests.V1.Controllers
{
    [TestFixture]
    public class ArrearsActionControllerTests
    {
        private ArrearsActionsController _controllerUnderTest;
        private Mock<IArrearsActionUsecase> _mockUsecase;
        private Mock<IGetAractionsByPropRefRequestValidator> _mockGetByPropRefValidator;

        [SetUp]
        public void Setup()
        {
            _mockUsecase = new Mock<IArrearsActionUsecase>();
            _mockGetByPropRefValidator = new Mock<IGetAractionsByPropRefRequestValidator>();
            _controllerUnderTest = new ArrearsActionsController(_mockUsecase.Object, _mockGetByPropRefValidator.Object);
        }

        [Test]
        public void Given_a_valid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_calls_the_usecase()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockUsecase.Verify(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }

        [Test]
        public void Given_a_valid_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_controller_calls_the_usecase_with_the_same_request_object()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockUsecase.Verify(u => u.GetByPropRef(It.Is<GetAractionsByPropRefRequest>(r => r == request)), Times.Once);
        }

        [Test]
        public void Given_a_successful_request__When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_returns_a_200_Ok_response()
        {
            // arrange
            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Returns<GetAractionsByPropRefResponse>(null);

            // act
            var response = _controllerUnderTest.GetAractionsByPropRef(new GetAractionsByPropRefRequest());

            // assert
            var response_type = response as ObjectResult;
            Assert.IsInstanceOf<OkObjectResult>(response_type);

            var response_code = response_type.StatusCode;
            Assert.AreEqual(200, response_code);
        }

        [Test]
        public void Given_a_successful_request__When_usecase_returns_its_result__Then_GetAractionsByPropRef_ArrearsActionController_wraps_it_up_And_returns_that_result_within_a_response_object()
        {
            // arrange
            var usecase_result = new GetAractionsByPropRefResponse(TestHelper.Generate_GetAractionsByPropRefRequest(), TestHelper.Generate_ListOfArrearsActions(), DateTime.Now);
            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Returns(usecase_result);

            // act
            var response = _controllerUnderTest.GetAractionsByPropRef(new GetAractionsByPropRefRequest());

            // assert
            var response_value = (response as ObjectResult)?.Value;
            Assert.AreSame(usecase_result, response_value);
        }

        #region Validator - Controller tests

        [Test]
        public void Given_a_request_When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_calls_GetAractionsByPropRefRequestValidator()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();
            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Returns<GetAractionsByPropRefResponse>(null);

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockGetByPropRefValidator.Verify(v => v.Validate(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }

        [Test]
        public void Given_a_request_When_GetAractionsByPropRef_ArrearsActionController_method_is_called__Then_it_calls_GetAractionsByPropRefRequestValidator_with_the_same_request_object()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();
            _mockUsecase.Setup(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>())).Returns<GetAractionsByPropRefResponse>(null);

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockGetByPropRefValidator.Verify(v => v.Validate(It.Is<GetAractionsByPropRefRequest>(r => r == request)), Times.Once);
        } 

        #endregion
    }
}
