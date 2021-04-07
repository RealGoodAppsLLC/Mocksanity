using System;

namespace RealGoodApps.Mocksanity
{
    public abstract class BaseMocksane<TInstance, TResult> : IDisposable
        where TInstance : class
    {
        internal readonly TInstance Instance;
        internal readonly MocksaneExpression MocksaneExpression;
        internal readonly Func<MocksaneParameters, TResult> ReturnsFunction;
        internal readonly Func<MocksaneParameters, bool> PredicateFunction;

        internal BaseMocksane(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
        {
            Instance = instance;
            MocksaneExpression = mocksaneExpression;
            ReturnsFunction = returnsFunction;
            PredicateFunction = predicateFunction;
        }

        internal abstract void InitializeHook();

        internal abstract void DestroyHook();

        public void Dispose()
        {
            DestroyHook();
        }
    }
}
