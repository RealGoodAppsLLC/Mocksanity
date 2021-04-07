using System;

namespace RealGoodApps.Mocksanity
{
    public struct Void
    {
    }

    public sealed class MocksaneVoid<TInstance> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        internal MocksaneVoid(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Action<MocksaneParameters> callbackFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, callbackFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            // TODO: Initialize the hook
        }

        internal override void DestroyHook()
        {
            // TODO: Destroy the hook
        }
    }
}
