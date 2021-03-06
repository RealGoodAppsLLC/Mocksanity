using System;

namespace RealGoodApps.Mocksanity
{
    public abstract class BaseMocksaneVoid<TInstance> : BaseMocksane<TInstance>
        where TInstance : class
    {
        internal readonly Action<MocksaneParameters> CallbackFunction;

        internal BaseMocksaneVoid(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Action<MocksaneParameters> callbackFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, predicateFunction)
        {
            CallbackFunction = callbackFunction;
        }
    }
}
