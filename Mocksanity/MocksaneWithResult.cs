using System;
using MonoMod.RuntimeDetour;

namespace RealGoodApps.Mocksanity
{
    public sealed class MocksaneWithResult<TInstance, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TResult>, TInstance, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TResult> originalFunction,
            TInstance instance)
        {
            var parameters = MocksaneParameters.Create();

            if (Instance != instance)
            {
                return originalFunction(instance);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TResult>, TInstance, TParam1, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TResult> originalFunction,
            TInstance instance,
            TParam1 param1)
        {
            var parameters = MocksaneParameters.Create(param1);

            if (Instance != instance)
            {
                return originalFunction(instance, param1);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1))
            {
                return originalFunction(instance, param1);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TResult>, TInstance, TParam1, TParam2, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2)
        {
            var parameters = MocksaneParameters.Create(param1, param2);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2))
            {
                return originalFunction(instance, param1, param2);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TResult>, TInstance, TParam1, TParam2, TParam3, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3))
            {
                return originalFunction(instance, param1, param2, param3);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4))
            {
                return originalFunction(instance, param1, param2, param3, param4);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9,
            TParam10 param10)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9)
                || !MocksaneExpression.ParameterPredicates[9].Invoke(param10))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9,
            TParam10 param10,
            TParam11 param11)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9)
                || !MocksaneExpression.ParameterPredicates[9].Invoke(param10)
                || !MocksaneExpression.ParameterPredicates[10].Invoke(param11))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9,
            TParam10 param10,
            TParam11 param11,
            TParam12 param12)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9)
                || !MocksaneExpression.ParameterPredicates[9].Invoke(param10)
                || !MocksaneExpression.ParameterPredicates[10].Invoke(param11)
                || !MocksaneExpression.ParameterPredicates[11].Invoke(param12))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9,
            TParam10 param10,
            TParam11 param11,
            TParam12 param12,
            TParam13 param13)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9)
                || !MocksaneExpression.ParameterPredicates[9].Invoke(param10)
                || !MocksaneExpression.ParameterPredicates[10].Invoke(param11)
                || !MocksaneExpression.ParameterPredicates[11].Invoke(param12)
                || !MocksaneExpression.ParameterPredicates[12].Invoke(param13))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
    public sealed class MocksaneWithResult<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult> : BaseMocksaneWithResult<TInstance, TResult>
        where TInstance : class
    {
        private Hook _hook;

        internal MocksaneWithResult(
            TInstance instance,
            MocksaneExpression mocksaneExpression,
            Func<MocksaneParameters, TResult> returnsFunction,
            Func<MocksaneParameters, bool> predicateFunction)
            : base(instance, mocksaneExpression, returnsFunction, predicateFunction)
        {
        }

        internal override void InitializeHook()
        {
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Func<Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public TResult HookCallback(
            Func<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14, TResult> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4,
            TParam5 param5,
            TParam6 param6,
            TParam7 param7,
            TParam8 param8,
            TParam9 param9,
            TParam10 param10,
            TParam11 param11,
            TParam12 param12,
            TParam13 param13,
            TParam14 param14)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);

            if (Instance != instance)
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            }
            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7)
                || !MocksaneExpression.ParameterPredicates[7].Invoke(param8)
                || !MocksaneExpression.ParameterPredicates[8].Invoke(param9)
                || !MocksaneExpression.ParameterPredicates[9].Invoke(param10)
                || !MocksaneExpression.ParameterPredicates[10].Invoke(param11)
                || !MocksaneExpression.ParameterPredicates[11].Invoke(param12)
                || !MocksaneExpression.ParameterPredicates[12].Invoke(param13)
                || !MocksaneExpression.ParameterPredicates[13].Invoke(param14))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                return originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
            }

            CallCount++;

            return ReturnsFunction != null
                ? ReturnsFunction(MocksaneParameters.Create(parameters))
                : default;
        }
    }
}
