using System;
using MonoMod.RuntimeDetour;

namespace RealGoodApps.Mocksanity
{
    public sealed class MocksaneVoid<TInstance> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance>, TInstance>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance> originalFunction,
            TInstance instance)
        {
            var parameters = MocksaneParameters.Create();

            if (Instance != instance)
            {
                originalFunction(instance);
                return;
            }

            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1>, TInstance, TParam1>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1> originalFunction,
            TInstance instance,
            TParam1 param1)
        {
            var parameters = MocksaneParameters.Create(param1);

            if (Instance != instance)
            {
                originalFunction(instance, param1);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1))
            {
                originalFunction(instance, param1);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2>, TInstance, TParam1, TParam2>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2)
        {
            var parameters = MocksaneParameters.Create(param1, param2);

            if (Instance != instance)
            {
                originalFunction(instance, param1, param2);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2))
            {
                originalFunction(instance, param1, param2);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3>, TInstance, TParam1, TParam2, TParam3>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3);

            if (Instance != instance)
            {
                originalFunction(instance, param1, param2, param3);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3))
            {
                originalFunction(instance, param1, param2, param3);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4>, TInstance, TParam1, TParam2, TParam3, TParam4>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4> originalFunction,
            TInstance instance,
            TParam1 param1,
            TParam2 param2,
            TParam3 param3,
            TParam4 param4)
        {
            var parameters = MocksaneParameters.Create(param1, param2, param3, param4);

            if (Instance != instance)
            {
                originalFunction(instance, param1, param2, param3, param4);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4))
            {
                originalFunction(instance, param1, param2, param3, param4);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5))
            {
                originalFunction(instance, param1, param2, param3, param4, param5);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
                return;
            }

            if (!MocksaneExpression.ParameterPredicates[0].Invoke(param1)
                || !MocksaneExpression.ParameterPredicates[1].Invoke(param2)
                || !MocksaneExpression.ParameterPredicates[2].Invoke(param3)
                || !MocksaneExpression.ParameterPredicates[3].Invoke(param4)
                || !MocksaneExpression.ParameterPredicates[4].Invoke(param5)
                || !MocksaneExpression.ParameterPredicates[5].Invoke(param6)
                || !MocksaneExpression.ParameterPredicates[6].Invoke(param7))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
    public sealed class MocksaneVoid<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> : BaseMocksaneVoid<TInstance>
        where TInstance : class
    {
        private Hook _hook;

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
            _hook = new Hook(
                MocksaneExpression.MethodInfo,
                new Action<Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>, TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14>(HookCallback));
        }

        internal override void DestroyHook()
        {
            _hook?.Dispose();
        }

        public void HookCallback(
            Action<TInstance, TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TParam11, TParam12, TParam13, TParam14> originalFunction,
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
                return;
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
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
                return;
            }
            if (PredicateFunction != null && !PredicateFunction(parameters))
            {
                originalFunction(instance, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14);
                return;
            }

            CallCount++;
            CallbackFunction?.Invoke(parameters);
        }
    }
}
