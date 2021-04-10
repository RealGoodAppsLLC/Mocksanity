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

                HandleArgumentExpression(argument);
            }
        }

        private void HandleArgumentExpression(Expression argument)
        {
            switch (argument)
            {
                case MemberExpression memberExpression:
                    HandleMemberExpression(memberExpression);
                    break;

                case ConstantExpression constantExpression:
                    HandleConstantExpression(constantExpression);
                    break;

                case MethodCallExpression argumentMethodCallExpression:
                    HandleMethodCallExpression(argumentMethodCallExpression, argument);
                    break;

                default:
                    throw new NotSupportedException(
                        $"The expression {argument} is not supported for smart predicates.");
            }
        }

        private void HandleMethodCallExpression(
            MethodCallExpression argumentMethodCallExpression,
            Expression argument)
        {
            var isMatchesMethod = argumentMethodCallExpression.Method.Equals(
                typeof(MocksanePredicates)
                    .GetMethod(nameof(MocksanePredicates.Matches))?
                    .MakeGenericMethod(argument.Type));

            if (isMatchesMethod)
            {
                if (argumentMethodCallExpression.Arguments.Count < 1)
                {
                    throw new InvalidOperationException(
                        "The matches method requires a parameter defining the predicate to use for the parameter.");
                }

                ParameterPredicates.Add(parameter =>
                {
                    var predicateBoundedType = typeof(Func<,>).MakeGenericType(argument.Type, typeof(bool));
                    var funcBoundedType = typeof(Func<>).MakeGenericType(predicateBoundedType);
                    var compiledFunction = Expression.Lambda(
                            funcBoundedType,
                            argumentMethodCallExpression.Arguments[0])
                        .Compile();

                    var predicate = compiledFunction.DynamicInvoke();
                    var invokeMethod = predicateBoundedType.GetMethod("Invoke");

                    if (invokeMethod == null)
                    {
                        return false;
                    }

                    return (bool)invokeMethod.Invoke(predicate, new[] {parameter});
                });

                return;
            }

            var isAnyMethod = argumentMethodCallExpression.Method.Equals(
                typeof(MocksanePredicates)
                    .GetMethod(nameof(MocksanePredicates.Any))?
                    .MakeGenericMethod(argument.Type));

            if (isAnyMethod)
            {
                ParameterPredicates.Add(parameter => true);
                return;
            }

            var methodBoundedType = typeof(Func<>).MakeGenericType(argument.Type);
            var compiledMethod = Expression.Lambda(methodBoundedType, argumentMethodCallExpression).Compile();

            var returnValue = compiledMethod.DynamicInvoke();
            ParameterPredicates.Add(parameter => parameter == returnValue || parameter.Equals(returnValue));
        }

        private void HandleConstantExpression(ConstantExpression constantExpression)
        {
            ParameterPredicates.Add(parameter =>
                parameter == constantExpression.Value || parameter.Equals(constantExpression.Value));
        }

        private void HandleMemberExpression(MemberExpression memberExpression)
        {
            ParameterPredicates.Add(parameter =>
            {
                var boundedType = typeof(Func<>).MakeGenericType(memberExpression.Type);
                var compiled = Expression.Lambda(boundedType, memberExpression).Compile();
                var returnValue = compiled.DynamicInvoke();
                return parameter == returnValue || parameter.Equals(returnValue);
            });
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
