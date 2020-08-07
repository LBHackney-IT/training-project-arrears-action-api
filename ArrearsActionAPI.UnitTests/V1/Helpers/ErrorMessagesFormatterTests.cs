using NUnit.Framework;
using ArrearsActionAPI.V1.Helpers;

namespace ArrearsActionAPI.UnitTests.V1.Helpers
{
    [TestFixture]
    public class ErrorMessagesFormatterTests
    {
        [Test]
        public void Given_a_list_of_validation_failures__When_FormatValidationFailures_formatter_method_is_called__Then_it_returns_a_list_of_corresponding_error_messages() //we don't check the message format. we only check that the related text was given as output.
        {
            //arrange
            var validation_failures_list = TestHelper.Generate_AListOfValidationFailures();
            var errorCount = validation_failures_list.Count;

            //act
            var formattedList = ErrorMessagesFormatter.FormatValidationFailures(validation_failures_list);

            //assert
            Assert.AreEqual(errorCount, formattedList.Count);

            for (int i = 0; i < errorCount; i++)
            {
                StringAssert.Contains(validation_failures_list[i].PropertyName, formattedList[i]);
                StringAssert.Contains(validation_failures_list[i].ErrorMessage, formattedList[i]);
            }
        }

        // No point in testing simpler methods as it's plain C# string concatinations. At that level I'd be testing Microsofts .NET rather than my application.
    }
}
