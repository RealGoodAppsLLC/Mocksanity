using System;

namespace RealGoodApps.Mocksanity
{
    public abstract class BaseMocksaneVoid<TInstance> : IDisposable
        where TInstance : class
    {
        internal readonly TInstance Instance;
        internal readonly MocksaneExpression MocksaneExpression;
        internal readonly Action<MocksaneParameters> CallbackFunction;
        internal readonly Func<MocksaneParameters, bool> PredicateFunction;

        internal BaseMocksaneVoid(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Action<MocksaneParameters> callbackFunction,
            Func<MocksaneParameters, bool> predicateFunction)
        {
            Instance = instance;
            MocksaneExpression = mocksaneExpression;
            CallbackFunction = callbackFunction;
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
