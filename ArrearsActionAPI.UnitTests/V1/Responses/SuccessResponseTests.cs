using ArrearsActionAPI.V1.Boundary;
using ArrearsActionAPI.V1.Errors;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArrearsActionAPI.UnitTests.V1.Responses
{
    [TestFixture]
    class SuccessResponseTests
    {
        #region Get Aractions By PropRef Response Tests

        [Test]
        public void When_ErrorResponse_constructor_is_called__Then_it_initializes_status_parameter_to_fail()
        {
            //act
            var success_response = new GetAractionsByPropRefResponse(null, null);

            //assert
            Assert.AreEqual(success_response.Status, "success");
        }

        #endregion
    }
}
