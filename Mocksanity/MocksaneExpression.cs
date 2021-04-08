using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace RealGoodApps.Mocksanity
{
    internal class MocksaneExpression
    {
        private MocksaneExpression(Expression expression)
        {
            ParameterPredicates = new List<Func<object, bool>>();
            ParameterTypes = new List<Type>();

            if (!(expression is LambdaExpression lambdaExpression))
            {
                throw new NotSupportedException("Currently you must pass a lambda expression to mock.");
            }

            if (!(lambdaExpression.Body is MethodCallExpression methodCallExpression))
            {
                throw new NotSupportedException("Currently we only support mocking simple method call expressions.");
            }

            MethodInfo = methodCallExpression.Method;

            foreach (var argument in methodCallExpression.Arguments)
            {
                if (!(argument is ConstantExpression constantExpression))
                {
                    throw new NotSupportedException("Only constant expressions are support for smart predicates.");
                }

                ParameterTypes.Add(constantExpression.Type);
                ParameterPredicates.Add(parameter => parameter == constantExpression.Value || parameter.Equals(constantExpression.Value));
            }
        }

        // TODO: This seems a little off
        public int ParameterCount => ParameterPredicates.Count;

        internal MethodInfo MethodInfo { get; }

        internal List<Func<object, bool>> ParameterPredicates { get; }

        internal List<Type> ParameterTypes { get; }

        internal static MocksaneExpression Evaluate(Expression expression)
        {
            return new MocksaneExpression(expression);
        }
    }
}
