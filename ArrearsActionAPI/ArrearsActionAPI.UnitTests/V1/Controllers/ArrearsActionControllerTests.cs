using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using ArrearsActionAPI.V1.Controllers;

namespace ArrearsActionAPI.UnitTests.V1.Controllers
{
    [TestFixture]
    public class ArrearsActionControllerTests
    {
        private ArrearsActionsController _controllerUnderTest;

        [SetUp]
        public void Setup()
        {
            _controllerUnderTest = new ArrearsActionsController();
        }

        [Test]
        public void Test ()
        {
            Assert.Pass();
        }
    }
}
