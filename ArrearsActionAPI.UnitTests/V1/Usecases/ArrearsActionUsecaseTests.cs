using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Gateways;
using ArrearsActionAPI.V1.Usecases;
using Moq;
using NUnit.Framework;

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

            // act
            _usecaseUnderTest.GetByPropRef(new GetAractionsByPropRefRequest());

            // assert
            _mockGateway.Verify(u => u.GetByPropRef(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void Given_a_request_object_When_GetByPropRef_ArrearsActionUsecase_method_is_called__Then_usecase_calls_the_gateway_with_the_same_request_object()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            _usecaseUnderTest.GetByPropRef(request);

            // assert
            _mockGateway.Verify(u => u.GetByPropRef(It.Is<string>(r => r == request.PropertyRef)), Times.Once);
        }

        [Test]
        public void When_Gateway_returns_its_result__Then_ArrearsActionUsecase_usecase_wraps_it_up_and_returns_that_result_within_a_response_object()
        {
            // arrange
            var gateway_response = TestHelper.Generate_ListOfArrearsActions();
            _mockGateway.Setup(g => g.GetByPropRef(It.IsAny<string>())).Returns(gateway_response);

            // act
            var usecase_response = _usecaseUnderTest.GetByPropRef(new GetAractionsByPropRefRequest());

            // assert
            Assert.AreSame(usecase_response.ArrearsActions, gateway_response);
        }

        [Test]
        public void Given_a_request_object_When_GetByPropRef_ArrearsActionUsecase_method_is_called__Then_usecase_response_object_contains_the_same_request_object()
        {
            // arrange
            var request = TestHelper.Generate_GetAractionsByPropRefRequest();

            // act
            var usecase_response = _usecaseUnderTest.GetByPropRef(request);

            // assert
            Assert.AreSame(usecase_response.Request, request);
        }
    }
}
