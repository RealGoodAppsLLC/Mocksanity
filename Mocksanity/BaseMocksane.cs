using System;

namespace RealGoodApps.Mocksanity
{
    public abstract class BaseMocksane<TInstance> : IDisposable
        where TInstance : class
    {
        internal readonly TInstance Instance;
        internal readonly MocksaneExpression MocksaneExpression;
        internal readonly Func<MocksaneParameters, bool> PredicateFunction;
        public int CallCount { get; protected set; }

        internal BaseMocksane(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, bool> predicateFunction)
        {
            Instance = instance;
            MocksaneExpression = mocksaneExpression;
            PredicateFunction = predicateFunction;
        }

        internal abstract void InitializeHook();

        internal abstract void DestroyHook();

        public void VerifyOnce()
        {
            Verify(1);
        }

        public void Verify(int expectedCallCount)
        {
            if (CallCount != expectedCallCount)
            {
                throw new MocksaneVerificationException(expectedCallCount, CallCount);
            }
        }

        public void Dispose()
        {
            DestroyHook();
        }
    }
}
