using System;

namespace RealGoodApps.Mocksanity
{
    /// <summary>
    /// An exception that is thrown when there is a mismatch between the call count
    /// of a mocked method and the expected call count.
    /// </summary>
    public sealed class MocksaneVerificationException : Exception
    {
        internal MocksaneVerificationException(
            int expectedCallCount,
            int actualCallCount)
            : base($"The method under verification was expected to be "
                   + $"called {expectedCallCount} times but was actually called {actualCallCount} times.")
        {
            ExpectedCallCount = expectedCallCount;
            ActualCallCount = actualCallCount;
        }

        internal MocksaneVerificationException()
        {
        }

        internal MocksaneVerificationException(string message) : base(message)
        {
        }

        internal MocksaneVerificationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the expected call count of the mocked method.
        /// </summary>
        public int ExpectedCallCount { get; }

        /// <summary>
        /// Gets the actual call count of the mocked method.
        /// </summary>
        public int ActualCallCount { get; }
    }
}
