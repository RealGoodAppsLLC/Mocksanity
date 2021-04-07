using System;

namespace RealGoodApps.Mocksanity
{
    public sealed class Mocksane<TInstance, TResult> : BaseMocksane<TInstance, TResult>
        where TInstance : class
    {
        internal Mocksane(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
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

        public TResult HookCallback(
            Func<TInstance, TResult> originalFunction,
            TInstance instance)
        {
            var parameters = MocksaneParameters.Create();

            if (Instance != instance
                || (PredicateFunction != null && !PredicateFunction(parameters)))
            {
                return originalFunction(instance);
            }

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
}
