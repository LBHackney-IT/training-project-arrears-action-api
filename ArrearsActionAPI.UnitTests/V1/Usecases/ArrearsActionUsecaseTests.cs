using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Gateways;
using ArrearsActionAPI.V1.Usecases;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrearsActionAPI.UnitTests.V1.Usecases
{
    [TestFixture]
    public class ArrearsActionUsecaseTests
    {
        private IArrearsActionUsecase _usecaseUnderTest;
        private Mock<IArrearsActionGateway> _mockGateway;

        [SetUp]
        public void Setup()
        {
            _mockGateway = new Mock<IArrearsActionGateway>();
            _usecaseUnderTest = new ArrearsActionUsecase(_mockGateway.Object);
        }

        [Test]
        public void When_GetByPropRef_ArrearsActionUsecase_method_is_called__Then_usecase_calls_the_gateway()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _usecaseUnderTest.GetByPropRef(request); //rename it...

            // assert
            _mockGateway.Verify(u => u.GetByPropRef(It.IsAny<GetAractionsByPropRefRequest>()), Times.Once);
        }
    }
}
