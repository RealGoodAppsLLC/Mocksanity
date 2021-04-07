using System;
using System.Linq.Expressions;

namespace RealGoodApps.Mocksanity
{
    public static class MocksaneInitializer
    {
        public static BaseMocksaneVoid<TInstance> Initialize<TInstance>(
            TInstance instance,
            Expression<Action<TInstance>> expression,
            Action<MocksaneParameters> callbackFunction = null,
            Func<MocksaneParameters, bool> predicateFunction = null)
            where TInstance : class
        {
            var evaluation = MocksaneExpression.Evaluate(expression);

            BaseMocksaneVoid<TInstance> mocksane;

            switch (evaluation.ParameterCount)
            {
                case 0:
                    mocksane = new MocksaneVoid<TInstance>(instance, evaluation, callbackFunction, predicateFunction);
                    break;
                default:
                    throw new InvalidOperationException("The expression has more than the maximum number of parameters.");
            }

            mocksane.InitializeHook();

            return mocksane;
        }

        public static BaseMocksane<TInstance, TResult> Initialize<TInstance, TResult>(
            TInstance instance,
            Expression<Func<TInstance, TResult>> expression,
            Func<MocksaneParameters, TResult> returnsFunction = null,
            Func<MocksaneParameters, bool> predicateFunction = null)
            where TInstance : class
        {
            var evaluation = MocksaneExpression.Evaluate(expression);

            BaseMocksane<TInstance, TResult> mocksane;

            switch (evaluation.ParameterCount)
            {
                case 0:
                    mocksane = new Mocksane<TInstance, TResult>(instance, evaluation, returnsFunction, predicateFunction);
                    break;
                default:
                    throw new InvalidOperationException("The expression has more than the maximum number of parameters.");
            }

            mocksane.InitializeHook();

            return mocksane;
        }
    }
}
