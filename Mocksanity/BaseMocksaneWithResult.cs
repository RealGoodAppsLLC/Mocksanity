using System;

namespace RealGoodApps.Mocksanity
{
    public abstract class BaseMocksaneWithResult<TInstance, TResult> : BaseMocksane<TInstance>
        where TInstance : class
    {
        internal readonly Func<MocksaneParameters, TResult> ReturnsFunction;

        internal BaseMocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, predicateFunction)
        {
            ReturnsFunction = returnsFunction;
        }
    }
}
