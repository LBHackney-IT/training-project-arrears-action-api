using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ArrearsActionAPI.V1.Controllers;
using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Usecases;
using Moq;

namespace ArrearsActionAPI.UnitTests.V1.Controllers
{
    [TestFixture]
    public class ArrearsActionControllerTests
    {
        private ArrearsActionsController _controllerUnderTest;
        private Mock<IArrearsActionUsecase> _mockUsecase;

        [SetUp]
        public void Setup()
        {
            _mockUsecase = new Mock<IArrearsActionUsecase>();
            _controllerUnderTest = new ArrearsActionsController(_mockUsecase.Object);
        }

        [TestCase("assa")]
        [TestCase("fff")]
        [TestCase("123")]
        public void Given_a_valid_request__When_GetByPropRef_ArrearsActionController_method_is_called__Then_controller_calls_the_usecase(string propRef)
        {
            // arrange
            var request = new GetAractionsByPropRefRequest() { PropertyRef = propRef };

            // act
            _controllerUnderTest.GetAractionsByPropRef(request);

            // assert
            _mockUsecase.Verify(u => u.ExecuteGet(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }
    }
}
