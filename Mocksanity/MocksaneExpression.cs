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
                ParameterTypes.Add(argument.Type);

                switch (argument)
                {
                    case MemberExpression memberExpression:
                        ParameterPredicates.Add(parameter =>
                        {
                            var boundedType = typeof(Func<>).MakeGenericType(memberExpression.Type);
                            var compiled = Expression.Lambda(boundedType, memberExpression).Compile();
                            var returnValue = compiled.DynamicInvoke();
                            return parameter == returnValue || parameter.Equals(returnValue);
                        });

                        break;
                    case ConstantExpression constantExpression:
                        ParameterPredicates.Add(parameter => parameter == constantExpression.Value || parameter.Equals(constantExpression.Value));
                        break;

                    default:
                        throw new NotSupportedException(
                            "Only constant expressions and member expressions are supported for smart predicates.");
                }
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
