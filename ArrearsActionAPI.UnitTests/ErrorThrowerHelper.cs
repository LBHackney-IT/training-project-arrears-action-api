using Bogus;
using System;
using System.Collections.Generic;
using ArrearsActionAPI.V1.Helpers;

namespace ArrearsActionAPI.UnitTests
{
    public static class ErrorThrowerHelper
    {
        private static int _numberOfCases = 12;
        private static int _numberOfSimpleCases = 7;
        private static Faker _faker = new Faker();

        public static Tuple<Exception, List<string>> Generate_ExceptionAndCorrespondinErrorMessages(ErrorThrowerOptions options = ErrorThrowerOptions.AllErrors)
        {
            List<string> error_messages = new List<string>();

            var random_exception = Generate_Error(options);

            try // throw random error
            {
                throw random_exception;
            }
            catch (Exception ex) when (ex.InnerException != null)
            {
                error_messages.Add(ex.Message);
                error_messages.Add(ex.InnerException.Message);
            }
            catch (Exception ex) // catch the expected error message
            {
                error_messages.Add(ex.Message);
            }

            return new Tuple<Exception, List<string>>(random_exception, error_messages);
        }

        public static Exception Generate_Error(ErrorThrowerOptions options = ErrorThrowerOptions.AllErrors)
        {
            int random_error_number; // triangulating unexpected exceptions

            switch (options)
            {
                case ErrorThrowerOptions.SimpleErrors: random_error_number = _faker.Random.Int(0, _numberOfSimpleCases - 1); break;
                case ErrorThrowerOptions.InnerErrors: random_error_number = _faker.Random.Int(_numberOfSimpleCases, _numberOfCases - 1); break;
                default: random_error_number = _faker.Random.Int(0, _numberOfCases - 1); break;
            }

            string str = _faker.Random.Hash().ToString(); // triangulating error messages

            switch (random_error_number)
            {
                case 0: return new OutOfMemoryException(str);
                case 1: return new IndexOutOfRangeException(str);
                case 2: return new ArgumentOutOfRangeException(str);
                case 3: return new MissingFieldException(str);
                case 4: return new OverflowException(str);
                case 5: return new TimeoutException(str);
                case 6: return new StackOverflowException(str);
                case 7: return Generate_InnerArgumentNullException(str);
                case 8: return Generate_InnerApplicationException(str);
                case 9: return Generate_InnerInvalidCastException(str);
                case 10: return Generate_InnerSystemException(str);
                default: return Generate_InnerAggregateException(str);
            }
        }

        private static SystemException Generate_InnerSystemException(string random_message_addon)
        {
            try { throw new SystemException("Inner SystemException exception thrown." + random_message_addon); }
            catch (SystemException e) { return new SystemException("Outer SystemException exception thrown.", e); }
        }

        private static InvalidCastException Generate_InnerInvalidCastException(string random_message_addon)
        {
            try { throw new InvalidCastException("Inner InvalidCastException exception thrown." + random_message_addon); }
            catch (InvalidCastException e) { return new InvalidCastException("Outer InvalidCastException exception thrown.", e); }
        }

        private static ArgumentNullException Generate_InnerArgumentNullException(string random_message_addon)
        {
            try { throw new ArgumentNullException("Inner ArgumentNullException exception thrown." + random_message_addon); }
            catch (ArgumentNullException e) { return new ArgumentNullException("Outer ArgumentNullException exception thrown.", e); }
        }

        private static ApplicationException Generate_InnerApplicationException(string random_message_addon)
        {
            try { throw new ApplicationException("Inner ApplicationException exception thrown." + random_message_addon); }
            catch (ApplicationException e) { return new ApplicationException("Outer ApplicationException exception thrown.", e); }
        }

        private static AggregateException Generate_InnerAggregateException(string random_message_addon)
        {
            try { throw new AggregateException("Inner AggregateException exception thrown." + random_message_addon); }
            catch (AggregateException e) { return new AggregateException("Outer AggregateException exception thrown.", e); }
        }

        public enum ErrorThrowerOptions
        {
            SimpleErrors,
            InnerErrors,
            AllErrors
        }
    }
}
