
using System;
using System.Linq.Expressions;
using BindingFlags = System.Reflection.BindingFlags;

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

            Type unboundedType;
            Type boundedType;

            switch (evaluation.ParameterCount)
            {
                case 0:
                    unboundedType = typeof(Mocksane<,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), typeof(TResult));
                    break;
                case 1:
                    unboundedType = typeof(Mocksane<,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], typeof(TResult));
                    break;
                case 2:
                    unboundedType = typeof(Mocksane<,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], typeof(TResult));
                    break;
                case 3:
                    unboundedType = typeof(Mocksane<,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], typeof(TResult));
                    break;
                case 4:
                    unboundedType = typeof(Mocksane<,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], typeof(TResult));
                    break;
                case 5:
                    unboundedType = typeof(Mocksane<,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], typeof(TResult));
                    break;
                case 6:
                    unboundedType = typeof(Mocksane<,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], typeof(TResult));
                    break;
                case 7:
                    unboundedType = typeof(Mocksane<,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], typeof(TResult));
                    break;
                case 8:
                    unboundedType = typeof(Mocksane<,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], typeof(TResult));
                    break;
                case 9:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], typeof(TResult));
                    break;
                case 10:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], evaluation.ParameterTypes[9], typeof(TResult));
                    break;
                case 11:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], evaluation.ParameterTypes[9], evaluation.ParameterTypes[10], typeof(TResult));
                    break;
                case 12:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], evaluation.ParameterTypes[9], evaluation.ParameterTypes[10], evaluation.ParameterTypes[11], typeof(TResult));
                    break;
                case 13:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], evaluation.ParameterTypes[9], evaluation.ParameterTypes[10], evaluation.ParameterTypes[11], evaluation.ParameterTypes[12], typeof(TResult));
                    break;
                case 14:
                    unboundedType = typeof(Mocksane<,,,,,,,,,,,,,,,>);
                    boundedType = unboundedType.MakeGenericType(typeof(TInstance), evaluation.ParameterTypes[0], evaluation.ParameterTypes[1], evaluation.ParameterTypes[2], evaluation.ParameterTypes[3], evaluation.ParameterTypes[4], evaluation.ParameterTypes[5], evaluation.ParameterTypes[6], evaluation.ParameterTypes[7], evaluation.ParameterTypes[8], evaluation.ParameterTypes[9], evaluation.ParameterTypes[10], evaluation.ParameterTypes[11], evaluation.ParameterTypes[12], evaluation.ParameterTypes[13], typeof(TResult));
                    break;
                default:
                    throw new InvalidOperationException("The expression has more than the maximum number of parameters.");
            }

            var constructorInfo = boundedType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new[]
                {
                    typeof(TInstance),
                    typeof(MocksaneExpression),
                    typeof(Func<MocksaneParameters, TResult>),
                    typeof(Func<MocksaneParameters, bool>),
                },
                null);

            if (constructorInfo == null)
            {
                throw new NotSupportedException("Something went wrong. This should never happen, please file a bug report!");
            }

            var mocksane = (BaseMocksane<TInstance, TResult>)constructorInfo.Invoke(new object[] { instance, evaluation, returnsFunction, predicateFunction });
            mocksane.InitializeHook();

            return mocksane;
        }
    }
}
