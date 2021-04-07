using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RealGoodApps.Mocksanity
{
    public sealed class MocksaneParameters
    {
        private readonly ReadOnlyCollection<MocksaneParameter> _parameters;

        internal MocksaneParameters(ReadOnlyCollection<MocksaneParameter> parameters)
        {
            _parameters = parameters;
        }

        public int Count => _parameters.Count;

        public MocksaneParameter GetParameter(int index)
        {
            if (index < 0 || index >= _parameters.Count)
            {
                throw new IndexOutOfRangeException($"The parameter index {index} is out of range.");
            }

            return _parameters[index];
        }

        public ReadOnlyCollection<MocksaneParameter> GetAllParameters()
        {
            return _parameters;
        }

        public static MocksaneParameters Create(params object[] parameters)
        {
            return new MocksaneParameters(parameters
                .Select((p, i) => new MocksaneParameter(i, p))
                .ToList()
                .AsReadOnly());
        }
    }

    public class MocksaneParameter
    {
        internal MocksaneParameter(int index, object value)
        {
            Index = index;
            RawValue = value;
        }

        public int Index { get; }

        public object RawValue { get; }

        public T GetValue<T>() => (T)RawValue;
    }
}
